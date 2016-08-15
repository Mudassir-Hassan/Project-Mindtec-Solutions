
function isEmpty(toChk) {
    var eltToChk = document.getElementById(toChk);
    var result = false;
    if (eltToChk.value.length > 0) {
        eltToChk.setAttribute("class", "textBox");
        result = false;
    }
    else {
        eltToChk.setAttribute("class", "errorTextBox");
        result = true;
    }
    return result;
}

function InRange(toChk, min, max) {
    var eltToChk = document.getElementById(toChk);
    if (eltToChk.value >= min && eltToChk.value <= max) {
        return true;
    }
    return false;
}