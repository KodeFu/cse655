#include "enclave_t.h"
#include "stdio.h"
#include "sgx_trts.h"
#include "sgx_thread.h"
#include "malloc.h"
#include "string.h"
#include "stdlib.h"

int g_value = 0;
int g_key = 0;
int g_intArray[20];
sgx_thread_mutex_t g_writeMutex;

char** str_split(char* a_str, const char a_delim);

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

char *getEncryptedTranaction(char value)
{
	switch (value)
	{
	case 0:
		return "2faf3cd1fa7dab725b7787e8cdd31192";
	case 1:
		return "b0732e6a0495d475e6850e7721f6d1e3";
	case 2:
		return "4b7f9a92d0fa696203a7d7ec01624dec";
	case 3:
		return "692e166a6cba48ef0d6e8774253eba65";
	case 4:
		return "2faf3cd1fa7dab725b7787e8cdd31192";
	case 5:
		return "b0732e6a0495d475e6850e7721f6d1e3";
	case 6:
		return "eeca8e5a107dc0eebe459c1fcc323082";
	case 7:
		return "22ed0b873434762ed1a1de4734f53df9";
	case 8:
		return "436d4e20d94ba4ace38f1e19a58c9c8b";
	case 9:
		return "403a2e8ef8ddb76820decd1597005077";
	case 10:
		return "81b39be28341c130baa7d622780d5735";
	default:
		return "18f39bd7c16e4d105149d549c4408c77";
		break;
	}
}

void enclaveChargeIt(const char* card_info, uint32_t card_info_size)
{
	char buf[BUFSIZ];

	// Decrypt
	for (int i = 0; i < card_info_size; i++)
	{
		buf[i] = ~card_info[i];
	}

	// split stuff
	char** tokens;
	tokens = str_split(buf, '-');

	char *amount = *(tokens + 0);
	char *cc = *(tokens + 1);
	char *exp = *(tokens + 2);
	char *name = *(tokens + 3);

	// transaction: buf is the encrypted data
	// transaction: add some bank info
	// mask the card number, send the rest back

	char ccMask[BUFSIZ];
	memset(ccMask, 0, BUFSIZ);
	for (int i=0; i < 16; i++)
	{
		ccMask[i] = cc[i];
	}
	for (int i=0; i < 12; i++)
	{
		ccMask[i] = 'X';
	}

	char transBytes[BUFSIZ];
	char *encTrans = getEncryptedTranaction( g_key++ );
	if (g_key > 11) g_key = 0;
	for (int i = 0; i < 32; i++)
	{
		transBytes[i] = encTrans[i];
	}
	transBytes[32] = '\0';

	char transaction[BUFSIZ];
	snprintf(transaction, BUFSIZ, "%s-%s-%s-%s", amount, ccMask, exp, transBytes /*buf card_info*/);

	// send decrypted
	ocall_send_receipt(transaction);
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


	ocall_print_string("hello");

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

// Using string split routine from SO.
// https://stackoverflow.com/questions/9210528/split-string-with-delimiters-in-c
char** str_split(char* a_str, const char a_delim)
{
    char** result    = 0;
    size_t count     = 0;
    char* tmp        = a_str;
    char* last_comma = 0;
    char delim[2];
    delim[0] = a_delim;
    delim[1] = 0;

    /* Count how many elements will be extracted. */
    while (*tmp)
    {
        if (a_delim == *tmp)
        {
            count++;
            last_comma = tmp;
        }
        tmp++;
    }

    /* Add space for trailing token. */
    count += last_comma < (a_str + strlen(a_str) - 1);

    /* Add space for terminating null string so caller
       knows where the list of returned strings ends. */
    count++;

    result = (char **) malloc(sizeof(char*) * count);

    if (result)
    {
        size_t idx  = 0;
        char* token = strtok(a_str, delim);

        while (token)
        {
            //assert(idx < count);
            *(result + idx++) = strndup(token, strlen(token));
            token = strtok(0, delim);
        }
        //assert(idx == count - 1);
        *(result + idx) = 0;
    }

    return result;
}
