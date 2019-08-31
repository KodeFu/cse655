#include "enclave_u.h"
#include <errno.h>

typedef struct ms_enclaveTestSGX_t {
	int ms_retval;
	int ms_input;
} ms_enclaveTestSGX_t;

typedef struct ms_enclaveTestSGXSetValue_t {
	int ms_input;
} ms_enclaveTestSGXSetValue_t;

typedef struct ms_enclaveTestSGXGetValue_t {
	int ms_retval;
} ms_enclaveTestSGXGetValue_t;

typedef struct ms_enclaveTestSGXWriteValue_t {
	int ms_retval;
	int ms_index;
	int ms_value;
} ms_enclaveTestSGXWriteValue_t;

typedef struct ms_enclaveChargeIt_t {
	const char* ms_card_info;
	uint32_t ms_card_info_size;
} ms_enclaveChargeIt_t;

typedef struct ms_ocall_print_string_t {
	const char* ms_str;
} ms_ocall_print_string_t;

typedef struct ms_ocall_send_receipt_t {
	const char* ms_str;
} ms_ocall_send_receipt_t;

typedef struct ms_sgx_oc_cpuidex_t {
	int* ms_cpuinfo;
	int ms_leaf;
	int ms_subleaf;
} ms_sgx_oc_cpuidex_t;

typedef struct ms_sgx_thread_wait_untrusted_event_ocall_t {
	int ms_retval;
	const void* ms_self;
} ms_sgx_thread_wait_untrusted_event_ocall_t;

typedef struct ms_sgx_thread_set_untrusted_event_ocall_t {
	int ms_retval;
	const void* ms_waiter;
} ms_sgx_thread_set_untrusted_event_ocall_t;

typedef struct ms_sgx_thread_setwait_untrusted_events_ocall_t {
	int ms_retval;
	const void* ms_waiter;
	const void* ms_self;
} ms_sgx_thread_setwait_untrusted_events_ocall_t;

typedef struct ms_sgx_thread_set_multiple_untrusted_events_ocall_t {
	int ms_retval;
	const void** ms_waiters;
	size_t ms_total;
} ms_sgx_thread_set_multiple_untrusted_events_ocall_t;

static sgx_status_t SGX_CDECL enclave_ocall_print_string(void* pms)
{
	ms_ocall_print_string_t* ms = SGX_CAST(ms_ocall_print_string_t*, pms);
	ocall_print_string(ms->ms_str);

	return SGX_SUCCESS;
}

static sgx_status_t SGX_CDECL enclave_ocall_send_receipt(void* pms)
{
	ms_ocall_send_receipt_t* ms = SGX_CAST(ms_ocall_send_receipt_t*, pms);
	ocall_send_receipt(ms->ms_str);

	return SGX_SUCCESS;
}

static sgx_status_t SGX_CDECL enclave_sgx_oc_cpuidex(void* pms)
{
	ms_sgx_oc_cpuidex_t* ms = SGX_CAST(ms_sgx_oc_cpuidex_t*, pms);
	sgx_oc_cpuidex(ms->ms_cpuinfo, ms->ms_leaf, ms->ms_subleaf);

	return SGX_SUCCESS;
}

static sgx_status_t SGX_CDECL enclave_sgx_thread_wait_untrusted_event_ocall(void* pms)
{
	ms_sgx_thread_wait_untrusted_event_ocall_t* ms = SGX_CAST(ms_sgx_thread_wait_untrusted_event_ocall_t*, pms);
	ms->ms_retval = sgx_thread_wait_untrusted_event_ocall(ms->ms_self);

	return SGX_SUCCESS;
}

static sgx_status_t SGX_CDECL enclave_sgx_thread_set_untrusted_event_ocall(void* pms)
{
	ms_sgx_thread_set_untrusted_event_ocall_t* ms = SGX_CAST(ms_sgx_thread_set_untrusted_event_ocall_t*, pms);
	ms->ms_retval = sgx_thread_set_untrusted_event_ocall(ms->ms_waiter);

	return SGX_SUCCESS;
}

static sgx_status_t SGX_CDECL enclave_sgx_thread_setwait_untrusted_events_ocall(void* pms)
{
	ms_sgx_thread_setwait_untrusted_events_ocall_t* ms = SGX_CAST(ms_sgx_thread_setwait_untrusted_events_ocall_t*, pms);
	ms->ms_retval = sgx_thread_setwait_untrusted_events_ocall(ms->ms_waiter, ms->ms_self);

	return SGX_SUCCESS;
}

static sgx_status_t SGX_CDECL enclave_sgx_thread_set_multiple_untrusted_events_ocall(void* pms)
{
	ms_sgx_thread_set_multiple_untrusted_events_ocall_t* ms = SGX_CAST(ms_sgx_thread_set_multiple_untrusted_events_ocall_t*, pms);
	ms->ms_retval = sgx_thread_set_multiple_untrusted_events_ocall(ms->ms_waiters, ms->ms_total);

	return SGX_SUCCESS;
}

static const struct {
	size_t nr_ocall;
	void * func_addr[7];
} ocall_table_enclave = {
	7,
	{
		(void*)(uintptr_t)enclave_ocall_print_string,
		(void*)(uintptr_t)enclave_ocall_send_receipt,
		(void*)(uintptr_t)enclave_sgx_oc_cpuidex,
		(void*)(uintptr_t)enclave_sgx_thread_wait_untrusted_event_ocall,
		(void*)(uintptr_t)enclave_sgx_thread_set_untrusted_event_ocall,
		(void*)(uintptr_t)enclave_sgx_thread_setwait_untrusted_events_ocall,
		(void*)(uintptr_t)enclave_sgx_thread_set_multiple_untrusted_events_ocall,
	}
};

sgx_status_t enclaveTestSGX(sgx_enclave_id_t eid, int* retval, int input)
{
	sgx_status_t status;
	ms_enclaveTestSGX_t ms;
	ms.ms_input = input;
	status = sgx_ecall(eid, 0, &ocall_table_enclave, &ms);
	if (status == SGX_SUCCESS && retval) *retval = ms.ms_retval;
	return status;
}

sgx_status_t enclaveTestSGXSetValue(sgx_enclave_id_t eid, int input)
{
	sgx_status_t status;
	ms_enclaveTestSGXSetValue_t ms;
	ms.ms_input = input;
	status = sgx_ecall(eid, 1, &ocall_table_enclave, &ms);
	return status;
}

sgx_status_t enclaveTestSGXGetValue(sgx_enclave_id_t eid, int* retval)
{
	sgx_status_t status;
	ms_enclaveTestSGXGetValue_t ms;
	status = sgx_ecall(eid, 2, &ocall_table_enclave, &ms);
	if (status == SGX_SUCCESS && retval) *retval = ms.ms_retval;
	return status;
}

sgx_status_t enclaveTestSGXWriteValue(sgx_enclave_id_t eid, int* retval, int index, int value)
{
	sgx_status_t status;
	ms_enclaveTestSGXWriteValue_t ms;
	ms.ms_index = index;
	ms.ms_value = value;
	status = sgx_ecall(eid, 3, &ocall_table_enclave, &ms);
	if (status == SGX_SUCCESS && retval) *retval = ms.ms_retval;
	return status;
}

sgx_status_t enclaveChargeIt(sgx_enclave_id_t eid, const char* card_info, uint32_t card_info_size)
{
	sgx_status_t status;
	ms_enclaveChargeIt_t ms;
	ms.ms_card_info = card_info;
	ms.ms_card_info_size = card_info_size;
	status = sgx_ecall(eid, 4, &ocall_table_enclave, &ms);
	return status;
}

sgx_status_t pair(sgx_enclave_id_t eid)
{
	sgx_status_t status;
	status = sgx_ecall(eid, 5, &ocall_table_enclave, NULL);
	return status;
}

sgx_status_t unpair(sgx_enclave_id_t eid)
{
	sgx_status_t status;
	status = sgx_ecall(eid, 6, &ocall_table_enclave, NULL);
	return status;
}

