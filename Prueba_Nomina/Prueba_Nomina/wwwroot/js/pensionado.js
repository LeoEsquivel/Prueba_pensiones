import { getEstadoCiviles, getTiposPensiones, guardarPensionado } from "./Services/http.services.js"
const d = document;

//URL base para los endpoints
const UrlApiBase = '/api/pensionado';

//Elementos del HTML;
//Formulario
const formPensionado = d.getElementById('formPensionado').elements;

//Botones
const btnGuardar = d.getElementById('btnGuardar');

//Selects
const selectEstadoCivil = d.getElementById('estado_civil');
const selectTipoPension = d.getElementById('tipo_pensiones');


//Eventos
btnGuardar.addEventListener('click', async () => {
    try { 
        const data = obtenerDatosFormulario();
        await guardarPensionado(UrlApiBase, data);
    } catch (error){
        console.log(error)
    })

});


const obtenerDatosFormulario = () => {
    return JSON.stringify({
        "No_activo": parseInt(formPensionado.no_activo.value),
        "Status_pago": 0,
        "Clave_pension": parseInt(formPensionado.clave_pension.value),
        "No_afiliado": parseInt(formPensionado.no_afiliado.value),
        "No_pension": parseInt(formPensionado.no_pension.value),
        "Sexo": parseInt(d.querySelector('input[name=sexo]:checked').value) || 0,
        "ApellidoP": formPensionado.apellidoP.value,
        "ApellidoM": formPensionado.apellidoM.value,
        "Nombre": formPensionado.nombre.value,
        "Fecha_nacimiento": formPensionado.fecha_nacimiento.value,
        "RFC": formPensionado.rfc.value,
        "CURP": formPensionado.curp.value,
        "Email": formPensionado.email.value,
        "Estado_civilId": parseInt(formPensionado.estado_civil.value),
        "Tipo_PensionId": parseInt(formPensionado.tipo_pensiones.value),
        "Cobro_indebido": formPensionado.cobre_indebido.checked,
    })
}

const llenarEstadoCivil = (estados) => {
    cargarSelect(selectEstadoCivil, 'estado', true, estados)
}

const llenarTipoPensiones = (pensiones) => {
    cargarSelect(selectTipoPension, 'tipo', true, pensiones);
}

//Funciones genericas
const validador = (formElement) => {

    if (formElement.tagName === 'SELECT') {
        return Number(formElement.value) > 0
    }

    if (formElement.tagName === 'INPUT') {
        return !formElement.value == "" || !formElement.value == null
    }
}


//selectElement: El select que se llenara en el HTML.
//key: La llave del objeto que contiene el dato que se mostrara como texto. (Es importante que el objeto tenga el campo id);
//defaultOption: Booleano usado para insertar una opción por defecto.
//data: Array con la información
const cargarSelect = (selectElement, key, defaultOption = false, data = null) => {

    if (!selectElement) {
        return "Error Elemento enviado es Null: La función debe recibir un elemento SELECT. Asegurese de que el elemento no sea null.";
    }

    if (selectElement.tagName != 'SELECT') {
        return "Error Elemento no es de tipo SELECT: La función solo puede recibir elementos de tipo SELECT."
    }

    if (defaultOption) {
        const defaultOption = document.createElement('option');
        defaultOption.value = 0;
        defaultOption.text = 'Seleccione una opción';
        defaultOption.selected = true;
        selectElement.add(defaultOption);
    }
    data.forEach(data => {
        const opt = document.createElement('option');
        opt.value = data.id;
        opt.text = data[key]
        selectElement.add(opt);
    })
}


window.addEventListener('load', async function () {
    try {
        const estadosCiviles = await getEstadoCiviles(`${UrlApiBase}/estados_civiles`);
        const pensiones = await getTiposPensiones(`${UrlApiBase}/tipo_pensiones`);

        llenarEstadoCivil(estadosCiviles);
        llenarTipoPensiones(pensiones);

    } catch (err) {
        console.log(err)
    }
});