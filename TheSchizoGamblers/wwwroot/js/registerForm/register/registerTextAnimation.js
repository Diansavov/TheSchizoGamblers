const inputs = document.querySelectorAll('#registerInput');

for (let i = 0; i < inputs.length; i++) {
    const input = inputs[i];
    if (input.value != '') {
        const parent = input.parentElement;
        const label = parent.querySelector('#registerLabel');
        label.classList.add('moving-label');
    }

    input.onchange = function () {
        const parent = input.parentElement;
        const label = parent.querySelector('#registerLabel');

        if (input.value == '') {
            label.classList.remove('moving-label');
            return;
        }
        label.classList.add('moving-label');
    }

}
