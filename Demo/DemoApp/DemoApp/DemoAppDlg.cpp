
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

/* OCall functions */
void ocall_print_string(const char *str)
{
	/* Proxy/Bridge will check the length and null-terminate
	 * the input string to prevent buffer overflow.
	 */
	printf("%s", str);
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
	: CDialogEx(IDD_MFCAPPLICATION1_DIALOG, pParent)
{
	m_hIcon = AfxGetApp()->LoadIcon(IDR_MAINFRAME);
}

void CDemoAppDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialogEx::DoDataExchange(pDX);
	DDX_Control(pDX, IDC_LIST4, listboxEnclave);
	DDX_Control(pDX, IDC_LIST1, listboxItems);
}

BEGIN_MESSAGE_MAP(CDemoAppDlg, CDialogEx)
	ON_WM_SYSCOMMAND()
	ON_WM_PAINT()
	ON_WM_QUERYDRAGICON()
	ON_BN_CLICKED(IDC_BUTTON1, &CDemoAppDlg::OnBnClickedButton1)
	ON_BN_CLICKED(IDC_BUTTON4, &CDemoAppDlg::OnBnClickedButton4)
	ON_BN_CLICKED(IDC_ADD_ITEM, &CDemoAppDlg::OnBnClickedAddItem)
	ON_BN_CLICKED(IDC_STARTENCLAVE, &CDemoAppDlg::OnBnClickedStartenclave)
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

	return TRUE;  // return TRUE  unless you set the focus to a control
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



void CDemoAppDlg::OnBnClickedButton1()
{
	// TODO: Add your control notification handler code here
	MessageBox(_T("Boo2!"), _T("Boo!"));
	
}


void CDemoAppDlg::OnBnClickedButton4()
{
	// TODO: Add your control notification handler code here
	listboxEnclave.AddString(_T("yo...."));
}


void CDemoAppDlg::OnBnClickedAddItem()
{
	// TODO: Add your control notification handler code here
	listboxItems.AddString(_T("bacon $4.00"));

	CString str = _T("bacon $4.00");
	int nTokenPos = 0;
	CString strToken = str.Tokenize(_T("$"), nTokenPos);
	MessageBox(strToken);
	strToken = str.Tokenize(_T("$"), nTokenPos);
	CString blah = _T("'");
	blah.Append(strToken);
	blah.Append(_T("'"));

	MessageBox(blah);

	float yo = 0.0;
	//yo = std::stod(strToken);
	std::string s((LPCTSTR)strToken);
	float d = std::stof(s);
}

//#define ENCLAVE_FILE _T("enclave.signed.dll")
#define ENCLAVE_FILE _T("\\Develop\\cse655\\Demo\\EnclaveTest\\enclave\\Debug\\enclave.signed.dll")

sgx_enclave_id_t g_eid = 0;

void CDemoAppDlg::OnBnClickedStartenclave()
{
	sgx_status_t sgxStatus = SGX_SUCCESS;
	sgx_enclave_id_t eid = 0;
	int returnValue = 0;
	sgx_launch_token_t token = { 0 };
	int updated = 0;;

	// Create the enclave
	sgxStatus = sgx_create_enclave(ENCLAVE_FILE, SGX_DEBUG_FLAG, &token, &updated, &eid, NULL);
	if (SGX_SUCCESS != sgxStatus)
	{
		printf("(%d) sgx error %#x, failed to create enclave, bailing.\n", GetCurrentThreadId(), sgxStatus);
		MessageBox(_T("Boo!"));
		//return -1;
	}

	printf("(%d) enclave '%ls' successfully loaded\n", GetCurrentThreadId(), ENCLAVE_FILE);

	sgx_destroy_enclave(eid);
}
