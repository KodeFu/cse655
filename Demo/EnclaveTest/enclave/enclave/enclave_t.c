#include "enclave_t.h"

#include "sgx_trts.h" /* for sgx_ocalloc, sgx_is_outside_enclave */
#include "sgx_lfence.h" /* for sgx_lfence */

#include <errno.h>
#include <mbusafecrt.h> /* for memcpy_s etc */
#include <stdlib.h> /* for malloc/free etc */

#define CHECK_REF_POINTER(ptr, siz) do {	\
	if (!(ptr) || ! sgx_is_outside_enclave((ptr), (siz)))	\
		return SGX_ERROR_INVALID_PARAMETER;\
} while (0)

#define CHECK_UNIQUE_POINTER(ptr, siz) do {	\
	if ((ptr) && ! sgx_is_outside_enclave((ptr), (siz)))	\
		return SGX_ERROR_INVALID_PARAMETER;\
} while (0)

#define CHECK_ENCLAVE_POINTER(ptr, siz) do {	\
	if ((ptr) && ! sgx_is_within_enclave((ptr), (siz)))	\
		return SGX_ERROR_INVALID_PARAMETER;\
} while (0)


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

#ifdef _MSC_VER
#pragma warning(push)
#pragma warning(disable: 4127)
#pragma warning(disable: 4200)
#endif

static sgx_status_t SGX_CDECL sgx_enclaveTestSGX(void* pms)
{
	CHECK_REF_POINTER(pms, sizeof(ms_enclaveTestSGX_t));
	//
	// fence after pointer checks
	//
	sgx_lfence();
	ms_enclaveTestSGX_t* ms = SGX_CAST(ms_enclaveTestSGX_t*, pms);
	sgx_status_t status = SGX_SUCCESS;



	ms->ms_retval = enclaveTestSGX(ms->ms_input);


	return status;
}

static sgx_status_t SGX_CDECL sgx_enclaveTestSGXSetValue(void* pms)
{
	CHECK_REF_POINTER(pms, sizeof(ms_enclaveTestSGXSetValue_t));
	//
	// fence after pointer checks
	//
	sgx_lfence();
	ms_enclaveTestSGXSetValue_t* ms = SGX_CAST(ms_enclaveTestSGXSetValue_t*, pms);
	sgx_status_t status = SGX_SUCCESS;



	enclaveTestSGXSetValue(ms->ms_input);


	return status;
}

static sgx_status_t SGX_CDECL sgx_enclaveTestSGXGetValue(void* pms)
{
	CHECK_REF_POINTER(pms, sizeof(ms_enclaveTestSGXGetValue_t));
	//
	// fence after pointer checks
	//
	sgx_lfence();
	ms_enclaveTestSGXGetValue_t* ms = SGX_CAST(ms_enclaveTestSGXGetValue_t*, pms);
	sgx_status_t status = SGX_SUCCESS;



	ms->ms_retval = enclaveTestSGXGetValue();


	return status;
}

static sgx_status_t SGX_CDECL sgx_enclaveTestSGXWriteValue(void* pms)
{
	CHECK_REF_POINTER(pms, sizeof(ms_enclaveTestSGXWriteValue_t));
	//
	// fence after pointer checks
	//
	sgx_lfence();
	ms_enclaveTestSGXWriteValue_t* ms = SGX_CAST(ms_enclaveTestSGXWriteValue_t*, pms);
	sgx_status_t status = SGX_SUCCESS;



	ms->ms_retval = enclaveTestSGXWriteValue(ms->ms_index, ms->ms_value);


	return status;
}

static sgx_status_t SGX_CDECL sgx_enclaveChargeIt(void* pms)
{
	CHECK_REF_POINTER(pms, sizeof(ms_enclaveChargeIt_t));
	//
	// fence after pointer checks
	//
	sgx_lfence();
	ms_enclaveChargeIt_t* ms = SGX_CAST(ms_enclaveChargeIt_t*, pms);
	sgx_status_t status = SGX_SUCCESS;
	const char* _tmp_card_info = ms->ms_card_info;
	uint32_t _tmp_card_info_size = ms->ms_card_info_size;
	size_t _len_card_info = _tmp_card_info_size;
	char* _in_card_info = NULL;

	CHECK_UNIQUE_POINTER(_tmp_card_info, _len_card_info);

	//
	// fence after pointer checks
	//
	sgx_lfence();

	if (_tmp_card_info != NULL && _len_card_info != 0) {
		_in_card_info = (char*)malloc(_len_card_info);
		if (_in_card_info == NULL) {
			status = SGX_ERROR_OUT_OF_MEMORY;
			goto err;
		}

		if (memcpy_s(_in_card_info, _len_card_info, _tmp_card_info, _len_card_info)) {
			status = SGX_ERROR_UNEXPECTED;
			goto err;
		}

	}

	enclaveChargeIt((const char*)_in_card_info, _tmp_card_info_size);
err:
	if (_in_card_info) free(_in_card_info);

	return status;
}

static sgx_status_t SGX_CDECL sgx_pair(void* pms)
{
	sgx_status_t status = SGX_SUCCESS;
	if (pms != NULL) return SGX_ERROR_INVALID_PARAMETER;
	pair();
	return status;
}

static sgx_status_t SGX_CDECL sgx_unpair(void* pms)
{
	sgx_status_t status = SGX_SUCCESS;
	if (pms != NULL) return SGX_ERROR_INVALID_PARAMETER;
	unpair();
	return status;
}

SGX_EXTERNC const struct {
	size_t nr_ecall;
	struct {void* call_addr; uint8_t is_priv;} ecall_table[7];
} g_ecall_table = {
	7,
	{
		{(void*)(uintptr_t)sgx_enclaveTestSGX, 0},
		{(void*)(uintptr_t)sgx_enclaveTestSGXSetValue, 0},
		{(void*)(uintptr_t)sgx_enclaveTestSGXGetValue, 0},
		{(void*)(uintptr_t)sgx_enclaveTestSGXWriteValue, 0},
		{(void*)(uintptr_t)sgx_enclaveChargeIt, 0},
		{(void*)(uintptr_t)sgx_pair, 0},
		{(void*)(uintptr_t)sgx_unpair, 0},
	}
};

SGX_EXTERNC const struct {
	size_t nr_ocall;
	uint8_t entry_table[7][7];
} g_dyn_entry_table = {
	7,
	{
		{0, 0, 0, 0, 0, 0, 0, },
		{0, 0, 0, 0, 0, 0, 0, },
		{0, 0, 0, 0, 0, 0, 0, },
		{0, 0, 0, 0, 0, 0, 0, },
		{0, 0, 0, 0, 0, 0, 0, },
		{0, 0, 0, 0, 0, 0, 0, },
		{0, 0, 0, 0, 0, 0, 0, },
	}
};


sgx_status_t SGX_CDECL ocall_print_string(const char* str)
{
	sgx_status_t status = SGX_SUCCESS;
	size_t _len_str = str ? strlen(str) + 1 : 0;

	ms_ocall_print_string_t* ms = NULL;
	size_t ocalloc_size = sizeof(ms_ocall_print_string_t);
	void *__tmp = NULL;


	CHECK_ENCLAVE_POINTER(str, _len_str);

	ocalloc_size += (str != NULL) ? _len_str : 0;

	__tmp = sgx_ocalloc(ocalloc_size);
	if (__tmp == NULL) {
		sgx_ocfree();
		return SGX_ERROR_UNEXPECTED;
	}
	ms = (ms_ocall_print_string_t*)__tmp;
	__tmp = (void *)((size_t)__tmp + sizeof(ms_ocall_print_string_t));
	ocalloc_size -= sizeof(ms_ocall_print_string_t);

	if (str != NULL) {
		ms->ms_str = (const char*)__tmp;
		if (memcpy_s(__tmp, ocalloc_size, str, _len_str)) {
			sgx_ocfree();
			return SGX_ERROR_UNEXPECTED;
		}
		__tmp = (void *)((size_t)__tmp + _len_str);
		ocalloc_size -= _len_str;
	} else {
		ms->ms_str = NULL;
	}
	
	status = sgx_ocall(0, ms);

	if (status == SGX_SUCCESS) {
	}
	sgx_ocfree();
	return status;
}

sgx_status_t SGX_CDECL ocall_send_receipt(const char* str)
{
	sgx_status_t status = SGX_SUCCESS;
	size_t _len_str = str ? strlen(str) + 1 : 0;

	ms_ocall_send_receipt_t* ms = NULL;
	size_t ocalloc_size = sizeof(ms_ocall_send_receipt_t);
	void *__tmp = NULL;


	CHECK_ENCLAVE_POINTER(str, _len_str);

	ocalloc_size += (str != NULL) ? _len_str : 0;

	__tmp = sgx_ocalloc(ocalloc_size);
	if (__tmp == NULL) {
		sgx_ocfree();
		return SGX_ERROR_UNEXPECTED;
	}
	ms = (ms_ocall_send_receipt_t*)__tmp;
	__tmp = (void *)((size_t)__tmp + sizeof(ms_ocall_send_receipt_t));
	ocalloc_size -= sizeof(ms_ocall_send_receipt_t);

	if (str != NULL) {
		ms->ms_str = (const char*)__tmp;
		if (memcpy_s(__tmp, ocalloc_size, str, _len_str)) {
			sgx_ocfree();
			return SGX_ERROR_UNEXPECTED;
		}
		__tmp = (void *)((size_t)__tmp + _len_str);
		ocalloc_size -= _len_str;
	} else {
		ms->ms_str = NULL;
	}
	
	status = sgx_ocall(1, ms);

	if (status == SGX_SUCCESS) {
	}
	sgx_ocfree();
	return status;
}

sgx_status_t SGX_CDECL sgx_oc_cpuidex(int cpuinfo[4], int leaf, int subleaf)
{
	sgx_status_t status = SGX_SUCCESS;
	size_t _len_cpuinfo = 4 * sizeof(int);

	ms_sgx_oc_cpuidex_t* ms = NULL;
	size_t ocalloc_size = sizeof(ms_sgx_oc_cpuidex_t);
	void *__tmp = NULL;

	void *__tmp_cpuinfo = NULL;

	CHECK_ENCLAVE_POINTER(cpuinfo, _len_cpuinfo);

	ocalloc_size += (cpuinfo != NULL) ? _len_cpuinfo : 0;

	__tmp = sgx_ocalloc(ocalloc_size);
	if (__tmp == NULL) {
		sgx_ocfree();
		return SGX_ERROR_UNEXPECTED;
	}
	ms = (ms_sgx_oc_cpuidex_t*)__tmp;
	__tmp = (void *)((size_t)__tmp + sizeof(ms_sgx_oc_cpuidex_t));
	ocalloc_size -= sizeof(ms_sgx_oc_cpuidex_t);

	if (cpuinfo != NULL) {
		ms->ms_cpuinfo = (int*)__tmp;
		__tmp_cpuinfo = __tmp;
		memset(__tmp_cpuinfo, 0, _len_cpuinfo);
		__tmp = (void *)((size_t)__tmp + _len_cpuinfo);
		ocalloc_size -= _len_cpuinfo;
	} else {
		ms->ms_cpuinfo = NULL;
	}
	
	ms->ms_leaf = leaf;
	ms->ms_subleaf = subleaf;
	status = sgx_ocall(2, ms);

	if (status == SGX_SUCCESS) {
		if (cpuinfo) {
			if (memcpy_s((void*)cpuinfo, _len_cpuinfo, __tmp_cpuinfo, _len_cpuinfo)) {
				sgx_ocfree();
				return SGX_ERROR_UNEXPECTED;
			}
		}
	}
	sgx_ocfree();
	return status;
}

sgx_status_t SGX_CDECL sgx_thread_wait_untrusted_event_ocall(int* retval, const void* self)
{
	sgx_status_t status = SGX_SUCCESS;

	ms_sgx_thread_wait_untrusted_event_ocall_t* ms = NULL;
	size_t ocalloc_size = sizeof(ms_sgx_thread_wait_untrusted_event_ocall_t);
	void *__tmp = NULL;


	__tmp = sgx_ocalloc(ocalloc_size);
	if (__tmp == NULL) {
		sgx_ocfree();
		return SGX_ERROR_UNEXPECTED;
	}
	ms = (ms_sgx_thread_wait_untrusted_event_ocall_t*)__tmp;
	__tmp = (void *)((size_t)__tmp + sizeof(ms_sgx_thread_wait_untrusted_event_ocall_t));
	ocalloc_size -= sizeof(ms_sgx_thread_wait_untrusted_event_ocall_t);

	ms->ms_self = self;
	status = sgx_ocall(3, ms);

	if (status == SGX_SUCCESS) {
		if (retval) *retval = ms->ms_retval;
	}
	sgx_ocfree();
	return status;
}

sgx_status_t SGX_CDECL sgx_thread_set_untrusted_event_ocall(int* retval, const void* waiter)
{
	sgx_status_t status = SGX_SUCCESS;

	ms_sgx_thread_set_untrusted_event_ocall_t* ms = NULL;
	size_t ocalloc_size = sizeof(ms_sgx_thread_set_untrusted_event_ocall_t);
	void *__tmp = NULL;


	__tmp = sgx_ocalloc(ocalloc_size);
	if (__tmp == NULL) {
		sgx_ocfree();
		return SGX_ERROR_UNEXPECTED;
	}
	ms = (ms_sgx_thread_set_untrusted_event_ocall_t*)__tmp;
	__tmp = (void *)((size_t)__tmp + sizeof(ms_sgx_thread_set_untrusted_event_ocall_t));
	ocalloc_size -= sizeof(ms_sgx_thread_set_untrusted_event_ocall_t);

	ms->ms_waiter = waiter;
	status = sgx_ocall(4, ms);

	if (status == SGX_SUCCESS) {
		if (retval) *retval = ms->ms_retval;
	}
	sgx_ocfree();
	return status;
}

sgx_status_t SGX_CDECL sgx_thread_setwait_untrusted_events_ocall(int* retval, const void* waiter, const void* self)
{
	sgx_status_t status = SGX_SUCCESS;

	ms_sgx_thread_setwait_untrusted_events_ocall_t* ms = NULL;
	size_t ocalloc_size = sizeof(ms_sgx_thread_setwait_untrusted_events_ocall_t);
	void *__tmp = NULL;


	__tmp = sgx_ocalloc(ocalloc_size);
	if (__tmp == NULL) {
		sgx_ocfree();
		return SGX_ERROR_UNEXPECTED;
	}
	ms = (ms_sgx_thread_setwait_untrusted_events_ocall_t*)__tmp;
	__tmp = (void *)((size_t)__tmp + sizeof(ms_sgx_thread_setwait_untrusted_events_ocall_t));
	ocalloc_size -= sizeof(ms_sgx_thread_setwait_untrusted_events_ocall_t);

	ms->ms_waiter = waiter;
	ms->ms_self = self;
	status = sgx_ocall(5, ms);

	if (status == SGX_SUCCESS) {
		if (retval) *retval = ms->ms_retval;
	}
	sgx_ocfree();
	return status;
}

sgx_status_t SGX_CDECL sgx_thread_set_multiple_untrusted_events_ocall(int* retval, const void** waiters, size_t total)
{
	sgx_status_t status = SGX_SUCCESS;
	size_t _len_waiters = total * sizeof(void*);

	ms_sgx_thread_set_multiple_untrusted_events_ocall_t* ms = NULL;
	size_t ocalloc_size = sizeof(ms_sgx_thread_set_multiple_untrusted_events_ocall_t);
	void *__tmp = NULL;


	CHECK_ENCLAVE_POINTER(waiters, _len_waiters);

	ocalloc_size += (waiters != NULL) ? _len_waiters : 0;

	__tmp = sgx_ocalloc(ocalloc_size);
	if (__tmp == NULL) {
		sgx_ocfree();
		return SGX_ERROR_UNEXPECTED;
	}
	ms = (ms_sgx_thread_set_multiple_untrusted_events_ocall_t*)__tmp;
	__tmp = (void *)((size_t)__tmp + sizeof(ms_sgx_thread_set_multiple_untrusted_events_ocall_t));
	ocalloc_size -= sizeof(ms_sgx_thread_set_multiple_untrusted_events_ocall_t);

	if (waiters != NULL) {
		ms->ms_waiters = (const void**)__tmp;
		if (memcpy_s(__tmp, ocalloc_size, waiters, _len_waiters)) {
			sgx_ocfree();
			return SGX_ERROR_UNEXPECTED;
		}
		__tmp = (void *)((size_t)__tmp + _len_waiters);
		ocalloc_size -= _len_waiters;
	} else {
		ms->ms_waiters = NULL;
	}
	
	ms->ms_total = total;
	status = sgx_ocall(6, ms);

	if (status == SGX_SUCCESS) {
		if (retval) *retval = ms->ms_retval;
	}
	sgx_ocfree();
	return status;
}

#ifdef _MSC_VER
#pragma warning(pop)
#endif
