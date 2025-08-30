function invokeTabKey(n) {
    var currInput = document.activeElement;
    if (currInput.tagName.toLowerCase() == "input") {
        var inputs = document.getElementsByTagName("input");
        var currInput = document.activeElement;
        for (var i = 0; i < inputs.length; i++) {
            if (inputs[i] == currInput) {
                var next = inputs[i + n];
                if (next && next.focus) {
                    next.focus();
                }
                break;
            }
        }
    }
}

function applyMask(elementId, mask) {
    const inputElement = document.getElementById(elementId);
    inputElement.addEventListener('input', function (event) {
        let value = event.target.value.replace(/\D/g, ''); // حذف کاراکترهای غیر عددی
        let formattedValue = '';

        // اعمال ماسک برای شماره تلفن
        if (mask === '(999) 999-9999' || mask === 'phone') {
            if (value.length <= 3) {
                formattedValue = `(${value}`;
            } else if (value.length <= 6) {
                formattedValue = `(${value.slice(0, 3)}) ${value.slice(3, 6)}`;
            } else {
                formattedValue = `(${value.slice(0, 3)}) ${value.slice(3, 6)}-${value.slice(6, 10)}`;
            }
        }
        // اعمال ماسک برای تاریخ
        else if (mask === '9999/99/99' || mask === 'date') {
            if (value.length <= 4) {
                formattedValue = value;
            } else if (value.length <= 6) {
                formattedValue = `${value.slice(0, 4)}/${value.slice(4, 6)}`;
            } else {
                formattedValue = `${value.slice(0, 4)}/${value.slice(4, 6)}/${value.slice(6, 8)}`;
            }
        }
        // اعمال ماسک برای قیمتها
        else if (mask === 'price') {
            let formatter = new Intl.NumberFormat("en-US");
            formattedValue = formatter.format(value);
        }
        event.target.value = formattedValue; // قرار دادن مقدار فرمت شده در ورودی
    });
}

function inputPassword() {
    var x = document.getElementById("input-password");
    var img = document.getElementById("img-password");
    if (x.type === "password") {
        x.type = "text";
        img.src = "/images/icons/eye-off.svg";  // تصویر چشم بسته یا حالت مخفی
    } else {
        x.type = "password";
        img.src = "/images/icons/eye.svg";      // تصویر چشم باز یا حالت نمایش
    }
}

function inputRepassword() {
    var x = document.getElementById("input-repassword");
    var img = document.getElementById("img-repassword");
    if (x.type === "password") {
        x.type = "text";
        img.src = "/images/icons/eye-off.svg";
    } else {
        x.type = "password";
        img.src = "/images/icons/eye.svg";
    }
}
