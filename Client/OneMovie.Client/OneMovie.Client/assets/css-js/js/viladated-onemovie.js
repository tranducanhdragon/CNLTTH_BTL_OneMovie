function validated() {
    var err = document.getElementById("err");
    var pw = document.forms['dangky']['Password'];
    if (pw.value.length <= 6) {
        pw.style.border = "1px solid red";
        err.innerHTML = "abc";
        err.style.visibility = 'visible';
        return false;
    }
}