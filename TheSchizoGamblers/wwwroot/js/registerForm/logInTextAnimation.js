const inputs = document.querySelectorAll('#loginInput');

for (let i = 0; i < inputs.length; i++) {
    const input = inputs[i];
    if (input.value != '') {
        const parent = input.parentElement;
        const label = parent.querySelector('#loginLabel');
        label.classList.add('moving-label');
    }

    input.onchange = function () {
        const parent = input.parentElement;
        const label = parent.querySelector('#loginLabel');

        if (input.value == '') {
            label.classList.remove('moving-label');
            return;
        }
        label.classList.add('moving-label');
    }

}
