window.ShowToastr=(type, message) => {
    if (type === 'success') {
        toastr.success(message, 'موفق');
    }

    if (type === 'error') {
        toastr.error(message, 'خطا');
    }

}


window.ShowSweetAlert = (type, message) => {
    if (type === 'success') {
        Swal.fire(
            'موفق !',
            message,
            'success'
        );
    }

    if (type === 'error') {
        Swal.fire(
            'خطا !',
            message,
            'error'
        );
    }

}

function showConfirmDelete() {
    $('#DeleteConfirm').modal('show');
}

function hideConfirmDelete() {
    $('#DeleteConfirm').modal('hide');
}