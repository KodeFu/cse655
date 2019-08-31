// test.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include "pch.h"
#include <tchar.h>
#include <iostream>
#include <time.h>
#include "sgx_urts.h"
#include "enclave_u.h"

#define ENCLAVE_FILE _T("enclave.signed.dll")

sgx_enclave_id_t g_eid = 0;
int threadCount = 0;

/* OCall functions */
void ocall_print_string(const char *str)
{
	/* Proxy/Bridge will check the length and null-terminate
	 * the input string to prevent buffer overflow.
	 */
	printf("%s", str);
}

void ocall_send_receipt(const char *str)
{
	/* Proxy/Bridge will check the length and null-terminate
	 * the input string to prevent buffer overflow.
	 */
	printf("got this back from enclave: %s\n", str);
	printf("did i get here");
}

int sgxTest(sgx_enclave_id_t eid)
{
	int returnValue = 0;
	int testValue = 5;
	int expectedValue = testValue + testValue;
	int sgxStatus = 0;

	sgxStatus = enclaveTestSGX(eid, &returnValue, testValue);

	if (SGX_SUCCESS != sgxStatus)
	{
		return -1;
	}

	if (returnValue != expectedValue)
	{
		return -2;
	}

	return 0;
}

int sgxTestGetValue(sgx_enclave_id_t eid)
{
	int returnValue = 0;
	int sgxStatus = 0;

	sgxStatus = enclaveTestSGXGetValue(eid, &returnValue);

	if (SGX_SUCCESS != sgxStatus)
	{
		return -1;
	}

	//printf("(%d) enclaveTestSGXGetValue() returned %d\n", GetCurrentThreadId(), returnValue);

	return 0;
}

int sgxTestSetValue(sgx_enclave_id_t eid)
{
	int testValue = 666;
	int sgxStatus = 0;

	sgxStatus = enclaveTestSGXSetValue(eid, testValue);

	if (SGX_SUCCESS != sgxStatus)
	{
		return -1;
	}

	printf("(%d) enclaveTestSGXSetValue() successful; value set to %d\n", GetCurrentThreadId(), testValue);

	return 0;
}

int sgxTestWriteValue(sgx_enclave_id_t eid, int index, int value)
{
	int sgxStatus = 0;
	int returnValue = 0;
	int local_index = index;
	int local_value = value;

	sgxStatus = enclaveTestSGXWriteValue(eid, &returnValue, local_index, local_value);

	if (SGX_SUCCESS != sgxStatus)
	{
		return -1;
	}

	printf("(%d) enclaveTestSGXWriteValue() successful\n", GetCurrentThreadId());

	return 0;
}

DWORD WINAPI myThread(void *data)
{
	int returnValue = 0;
	time_t t;

	srand((unsigned)time(0));

	printf("    (%d) calling enclave from thread\n", GetCurrentThreadId());

	returnValue = sgxTestWriteValue(g_eid, threadCount++, GetCurrentThreadId());
	//sgxTestSetValue(g_eid);
	if (0 != returnValue)
	{
		printf("        (%d) sgxTestWriteValue() returned %d, bailing.\n", GetCurrentThreadId(), returnValue);
		return -1;
	}

	printf("        (%d) thread returning ok\n", GetCurrentThreadId());
}

int main()
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
		return -1;
	}

	printf("(%d) enclave '%ls' successfully loaded\n", GetCurrentThreadId(), ENCLAVE_FILE);
/*
	// Make sure SGX is working
	returnValue = sgxTest(eid);
	if (0 != returnValue)
	{
		printf("(%d) sgxTest() returned %d, bailing.\n", GetCurrentThreadId(), returnValue);
		return -1;
	}

	// Create a thread test
	// We set a value in this thread and get the value in the myThread thread.
	returnValue = sgxTestSetValue(eid);
	if (0 != returnValue)
	{
		printf("(%d) sgxTestSetValue() returned %d, bailing.\n", GetCurrentThreadId(), returnValue);
		return -1;
	}

	g_eid = eid;
	HANDLE thread[20];
	for (int i = 0; i < 20; i++)
	{
		thread[i] = CreateThread(NULL, 0, myThread, NULL, 0, NULL);
	}
	WaitForMultipleObjects(20, thread, TRUE, INFINITE);

    printf("(%d) sgxTest() passed\n", GetCurrentThreadId());
	*/

	// Charge It
	char card_info[512];
	sprintf_s(card_info, "4353 546456 345456 Mudit Vats");
	int card_info_len = strlen(card_info);
	printf("card_info_len = %d\n", card_info_len);
	enclaveChargeIt(eid, card_info, card_info_len);


	printf("(%d) done\n", GetCurrentThreadId());
	sgx_destroy_enclave(eid);
}

