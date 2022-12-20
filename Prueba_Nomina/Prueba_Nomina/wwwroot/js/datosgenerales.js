const d = document;

//Botones
const btnGuardar = d.getElementById('btnGuardar');

const formPensionado = d.getElementById('formPensionado');


btnGuardar.addEventListener('click', () => {
    formPensionado.submit();
})
