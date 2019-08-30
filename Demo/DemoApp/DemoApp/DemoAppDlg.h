
// MFCApplication1Dlg.h : header file
//

#pragma once


// CMFCApplication1Dlg dialog
class CDemoAppDlg : public CDialogEx
{
// Construction
public:
	CDemoAppDlg(CWnd* pParent = nullptr);	// standard constructor

// Dialog Data
#ifdef AFX_DESIGN_TIME
	enum { IDD = IDD_DEMOAPP_DIALOG };
#endif

	protected:
	virtual void DoDataExchange(CDataExchange* pDX);	// DDX/DDV support


// Implementation
protected:
	HICON m_hIcon;

	// Generated message map functions
	virtual BOOL OnInitDialog();
	afx_msg void OnSysCommand(UINT nID, LPARAM lParam);
	afx_msg void OnPaint();
	afx_msg HCURSOR OnQueryDragIcon();
	DECLARE_MESSAGE_MAP()
public:
//	afx_msg void OnBnClickedButton1();
	CListBox listboxEnclave;
	afx_msg void OnBnClickedButton4();
	afx_msg void OnBnClickedButton3();
	CListBox listboxItems;
	afx_msg void OnBnClickedAddItem();
	afx_msg void OnBnClickedStartenclave();
	afx_msg void OnBnClickedBacon();
	afx_msg void OnBnClickedEggs();
	afx_msg void OnBnClickedMilk();
	//CStatic labelTotal;
	float nTotal;
	CString ccName;
	CString ccCardNumber;
	CString ccExpiration;

};
