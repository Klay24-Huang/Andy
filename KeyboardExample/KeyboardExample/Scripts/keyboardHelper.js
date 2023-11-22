const Keyboard = window.SimpleKeyboard.default;

// dom selector 不限定id or class 
let selectedInput;

function createKeyboard(defaultInput = '') {
    // 預設綁定
    if (defaultInput !== '') {
        selectedInput = defaultInput
    }

    let keyboard = new Keyboard({
        onChange: input => onChange(input),
        onKeyPress: button => onKeyPress(button),
        layout: {
            default: ["q w e r t y u i o p", "a s d f g h j k l", "{shift} z x c v b n m {bksp}", "{space}", "{enter}"],
            onlyNums: ["1 2 3", "4 5 6", "7 8 9", "{bksp}", "0"]
        }
    });

    keyboard.setOptions({
        layoutName: getLayoutName()
    });


document.querySelectorAll('input').forEach(input => {
    input.addEventListener("focus", onInputFocus);
    // Optional: Use if you want to track input changes
    // made without simple-keyboard
    input.addEventListener("input", onInputChange);
});

//用class判斷是否切換至數字鍵盤
function getLayoutName(seletor) {
    return document.querySelector(selectedInput).classList.contains('keyboard-only-nums') ? 'onlyNums' : 'default'
}

function onInputFocus(event) {
    selectedInput = `#${event.target.id}`;

    keyboard.setOptions({
        inputName: event.target.id,
        layoutName: getLayoutName(selectedInput)
    });
}

function onInputChange(event) {
    keyboard.setInput(event.target.value, event.target.id);
}

function onChange(input) {
    console.log("Input changed", input);
    document.querySelector(selectedInput).value = input;
}

function onKeyPress(button) {
    console.log("Button pressed", button);
}
}


//let layout = onlyNums
//    ? {
//        default: ["1 2 3", "4 5 6", "7 8 9", "{bksp}", "0"]
//    }
//    : {
//        default: ["q w e r t y u i o p", "a s d f g h j k l", "{shift} z x c v b n m {bksp}", "{space}", "{enter}"]
//    };

//const keyboard = new Keyboard({
//    onChange: input => onChange(input),
//    onKeyPress: button => onKeyPress(button),
//    layout: layout
//});