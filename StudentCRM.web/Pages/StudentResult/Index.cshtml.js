function FuncAdd(message, data) {
    
    showToastr('success', message);
    GetHtmlWithAjax(`${location.pathname}?handler=ShowResult`, { studentId: data }, 'showResult', null);
}

function showResult(data) {
    
    $('#myResultContent').html(data);
    $('.register-left').addClass("d-none");

}
