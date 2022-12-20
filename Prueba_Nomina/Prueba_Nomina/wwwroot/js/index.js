const d = document;

const btnAgregar = d.getElementById('btnAgregar');

btnAgregar.addEventListener('click', () => {
    IndexListadoViewModel.pensionados.push(new pensionadoElementoListadoViewModel({id: 0, nombre: ''}));
})