
// MFCApplication1Dlg.cpp : implementation file
//
#include "stdafx.h"
#include "DemoApp.h"
#include "DemoAppDlg.h"
#include "afxdialogex.h"
#include <string>

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


#include "sgx_urts.h"
#include "enclave_u.h"

//#define ENCLAVE_FILE _T("enclave.signed.dll")
#define ENCLAVE_FILE _T("\\Develop\\cse655\\Demo\\EnclaveTest\\enclave\\Debug\\enclave.signed.dll")

sgx_enclave_id_t g_eid = 0;
CListBox *g_listboxEnclave;
CDemoAppDlg *g_demoAppDlg;

/* OCall functions */
void ocall_print_string(const char *str)
{
	/* Proxy/Bridge will check the length and null-terminate
	 * the input string to prevent buffer overflow.
	 */
	CString buf;
	buf.Format(_T("T: %s"), str);
	g_listboxEnclave->AddString(buf);
}

void ocall_send_receipt(const char *str)
{
	/* Proxy/Bridge will check the length and null-terminate
	 * the input string to prevent buffer overflow.
	 */
	CString buf;
	buf.Format(_T("T: %s"), str);

	// Split strings
	int nTokenPos = 0;
	CString cstr;
	cstr.Format(_T("%s"), str);
	CString transChargeAmt = cstr.Tokenize(_T("-"), nTokenPos);
	CString transCC = cstr.Tokenize(_T("-"), nTokenPos);
	cstr.Tokenize(_T("-"), nTokenPos);
	CString transName = cstr.Tokenize(_T("-"), nTokenPos);

	g_demoAppDlg->transChargeAmt = transChargeAmt;
	g_demoAppDlg->transCC = transCC;
	g_demoAppDlg->transName = transName;
	g_demoAppDlg->UpdateData(false);
	
	g_listboxEnclave->AddString(buf);
}

// CAboutDlg dialog used for App About

class CAboutDlg : public CDialogEx
{
public:
	CAboutDlg();

// Dialog Data
#ifdef AFX_DESIGN_TIME
	enum { IDD = IDD_ABOUTBOX };
#endif

	protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV support

// Implementation
protected:
	DECLARE_MESSAGE_MAP()
};

CAboutDlg::CAboutDlg() : CDialogEx(IDD_ABOUTBOX)
{
}

void CAboutDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialogEx::DoDataExchange(pDX);
}

BEGIN_MESSAGE_MAP(CAboutDlg, CDialogEx)
END_MESSAGE_MAP()


// CMFCApplication1Dlg dialog



CDemoAppDlg::CDemoAppDlg(CWnd* pParent /*=nullptr*/)
	: CDialogEx(IDD_DEMOAPP_DIALOG, pParent)
	, nTotal(0.0)
	, ccName(_T(""))
	, ccCardNumber(_T(""))
	, ccExpiration(_T(""))
	, transPayment(_T(""))
	, transCC(_T(""))
	, transName(_T(""))
	, transChargeAmt(_T(""))
{
	m_hIcon = AfxGetApp()->LoadIcon(IDR_MAINFRAME);
	g_listboxEnclave = &listboxEnclave;

	g_demoAppDlg = this;
}

void CDemoAppDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialogEx::DoDataExchange(pDX);
	DDX_Control(pDX, IDC_LIST_ENCLAVE, listboxEnclave);
	DDX_Control(pDX, IDC_LIST_SHOPPING, listboxItems);
	DDX_Text(pDX, IDC_EDIT_NAME, ccName);
	DDX_Text(pDX, IDC_EDIT_CREDITCARD, ccCardNumber);
	DDX_Text(pDX, IDC_EDIT_EXPIRATION, ccExpiration);
	DDX_Text(pDX, IDC_TOTAL, nTotal);
	DDX_Text(pDX, IDC_TRANS_CC, transCC);
	DDX_Text(pDX, IDC_TRANS_NAME, transName);
	DDX_Text(pDX, IDC_TRANS_CHARGEAMT, transChargeAmt);
}

BEGIN_MESSAGE_MAP(CDemoAppDlg, CDialogEx)
	ON_WM_SYSCOMMAND()
	ON_WM_PAINT()
	ON_WM_QUERYDRAGICON()
	ON_BN_CLICKED(IDC_STARTENCLAVE, &CDemoAppDlg::OnBnClickedStartenclave)
	ON_BN_CLICKED(IDC_BACON, &CDemoAppDlg::OnBnClickedBacon)
	ON_BN_CLICKED(IDC_EGGS, &CDemoAppDlg::OnBnClickedEggs)
	ON_BN_CLICKED(IDC_MILK, &CDemoAppDlg::OnBnClickedMilk)
	ON_BN_CLICKED(IDC_STOPENCLAVE, &CDemoAppDlg::OnBnClickedStopenclave)
	ON_BN_CLICKED(IDC_RESET, &CDemoAppDlg::OnBnClickedReset)
	ON_BN_CLICKED(IDC_CHARGEIT, &CDemoAppDlg::OnBnClickedChargeit)
END_MESSAGE_MAP()


// CMFCApplication1Dlg message handlers

BOOL CDemoAppDlg::OnInitDialog()
{
	CDialogEx::OnInitDialog();

	// Add "About..." menu item to system menu.

	// IDM_ABOUTBOX must be in the system command range.
	ASSERT((IDM_ABOUTBOX & 0xFFF0) == IDM_ABOUTBOX);
	ASSERT(IDM_ABOUTBOX < 0xF000);

	CMenu* pSysMenu = GetSystemMenu(FALSE);
	if (pSysMenu != nullptr)
	{
		BOOL bNameValid;
		CString strAboutMenu;
		bNameValid = strAboutMenu.LoadString(IDS_ABOUTBOX);
		ASSERT(bNameValid);
		if (!strAboutMenu.IsEmpty())
		{
			pSysMenu->AppendMenu(MF_SEPARATOR);
			pSysMenu->AppendMenu(MF_STRING, IDM_ABOUTBOX, strAboutMenu);
		}
	}

	// Set the icon for this dialog.  The framework does this automatically
	//  when the application's main window is not a dialog
	SetIcon(m_hIcon, TRUE);			// Set big icon
	SetIcon(m_hIcon, FALSE);		// Set small icon

	// TODO: Add extra initialization here
	Reset();

	return TRUE;  // return TRUE  unless you set the focus to a control
}

void CDemoAppDlg::Reset()
{
	OnBnClickedStopenclave();

	nTotal = 0.00;
	ccName = "John Smith";
	ccCardNumber = "4571661043233207";
	ccExpiration = "06/2020";
	UpdateData(false);

	listboxEnclave.ResetContent();
	listboxItems.ResetContent();
}

void CDemoAppDlg::OnSysCommand(UINT nID, LPARAM lParam)
{
	if ((nID & 0xFFF0) == IDM_ABOUTBOX)
	{
		CAboutDlg dlgAbout;
		dlgAbout.DoModal();
	}
	else
	{
		CDialogEx::OnSysCommand(nID, lParam);
	}
}

// If you add a minimize button to your dialog, you will need the code below
//  to draw the icon.  For MFC applications using the document/view model,
//  this is automatically done for you by the framework.

void CDemoAppDlg::OnPaint()
{
	if (IsIconic())
	{
		CPaintDC dc(this); // device context for painting

		SendMessage(WM_ICONERASEBKGND, reinterpret_cast<WPARAM>(dc.GetSafeHdc()), 0);

		// Center icon in client rectangle
		int cxIcon = GetSystemMetrics(SM_CXICON);
		int cyIcon = GetSystemMetrics(SM_CYICON);
		CRect rect;
		GetClientRect(&rect);
		int x = (rect.Width() - cxIcon + 1) / 2;
		int y = (rect.Height() - cyIcon + 1) / 2;

		// Draw the icon
		dc.DrawIcon(x, y, m_hIcon);
	}
	else
	{
		CDialogEx::OnPaint();
	}
}

// The system calls this function to obtain the cursor to display while the user drags
//  the minimized window.
HCURSOR CDemoAppDlg::OnQueryDragIcon()
{
	return static_cast<HCURSOR>(m_hIcon);
}


void CDemoAppDlg::OnBnClickedBacon()
{
	listboxItems.AddString(_T("Smoked Bacon\t$3.99"));
	
	// Update total
	UpdateData(true);
	nTotal += 3.99;
	UpdateData(false);
}


void CDemoAppDlg::OnBnClickedEggs()
{
	listboxItems.AddString(_T("Grade A Eggs\t$0.99"));

	// Update total
	UpdateData(true);
	nTotal += 0.99;
	UpdateData(false);
}


void CDemoAppDlg::OnBnClickedMilk()
{
	listboxItems.AddString(_T("Whole Milk\t$2.98"));

	// Update total
	UpdateData(true);
	nTotal += 2.97;
	UpdateData(false);
}

void CDemoAppDlg::OnBnClickedStartenclave()
{
	sgx_status_t sgxStatus = SGX_SUCCESS;
	int returnValue = 0;
	sgx_launch_token_t token = { 0 };
	int updated = 0;;

	// Create the enclave
	sgxStatus = sgx_create_enclave(ENCLAVE_FILE, SGX_DEBUG_FLAG, &token, &updated, &g_eid, NULL);
	if (SGX_SUCCESS != sgxStatus)
	{
		CString buf;
		buf.Format("U: sgx error %#x, failed to create enclave, bailing.\n", sgxStatus);
		listboxEnclave.AddString(buf);
	}

	CString buf;
	buf.Format(_T("U: enclave successfully loaded."));
	listboxEnclave.AddString(buf);

	int testValue = 10;
	sgxStatus = enclaveTestSGX(g_eid, &returnValue, testValue);

	if (SGX_SUCCESS != sgxStatus)
	{
		buf.Format(_T("U: (%d) enclave test failed."), GetCurrentThreadId());
		listboxEnclave.AddString(buf);
	}

	buf.Format(_T("U: enclave test successful."));
	listboxEnclave.AddString(buf);

}

void CDemoAppDlg::OnBnClickedStopenclave()
{
	CString buf;

	if (g_eid != 0)
	{
		sgx_destroy_enclave(g_eid);
	
		buf.Format("U: enclave successfully unloaded.");
		listboxEnclave.AddString(buf);

		return;
	}

	buf.Format(_T("U: enclave not currently loaded."));
	listboxEnclave.AddString(buf);
}


void CDemoAppDlg::OnBnClickedReset()
{
	Reset();
}


void CDemoAppDlg::OnBnClickedChargeit()
{
	// Encrypt data as a string
	ccName;
	ccCardNumber;
	ccExpiration;
	nTotal;

	CString encrypted;
	encrypted.Format(_T("%.2f-%s-%s-%s"), nTotal, ccCardNumber, ccExpiration, ccName);
	char buf[100];
	strcpy_s(buf, encrypted.GetString());

	size_t len = strlen(buf);

	// Encrypt
	for (int i = 0; i < len; i++)
	{
		buf[i] = ~buf[i];
	}

	listboxEnclave.AddString(encrypted);

	// Send to enclave
	char card_info[512];
	sprintf_s(card_info, buf);
	int card_info_len = strlen(card_info);
	printf("card_info_len = %d\n", card_info_len);
	enclaveChargeIt(g_eid, card_info, card_info_len);
}
