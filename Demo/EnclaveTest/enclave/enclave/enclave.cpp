#include "enclave_t.h"
#include "stdio.h"
#include "sgx_trts.h"
#include "sgx_thread.h"
#include "malloc.h"
#include "string.h"

int g_value = 0;
int g_intArray[20];
sgx_thread_mutex_t g_writeMutex;

/*
 * printf:
 *   Invokes OCALL to display the enclave buffer to the terminal.
 */
void printf(const char *fmt, ...)
{
	char buf[BUFSIZ] = { '\0' };
	va_list ap;
	va_start(ap, fmt);
	vsnprintf(buf, BUFSIZ, fmt, ap);
	va_end(ap);
	ocall_print_string(buf);
}

int enclaveTestSGX(int input)
{
	// init
	sgx_thread_mutex_init(&g_writeMutex, NULL);
	g_value = 0;
	for (int i = 0; i < 20; i++)
	{
		g_intArray[i] = 0;
	}

	return input + input;
}

void enclaveTestSGXSetValue(int input)
{
	g_value = input;
}

int enclaveTestSGXGetValue()
{
	return g_value;
}

int enclaveTestSGXWriteValue(int index, int value)
{
	sgx_thread_mutex_lock(&g_writeMutex);
	g_intArray[index] = value;
	for (int i = 0; i < 20; i++)
	{
		printf("g_intArray[%d]=%d\n", i, g_intArray[i]);
	}
	sgx_thread_mutex_unlock(&g_writeMutex);

	return 0;
}

