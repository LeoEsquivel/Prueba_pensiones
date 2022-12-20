import http from './http.js';

export const getEstadoCiviles = async (url) => {
    return http.GET(url)
               .then((res) => {
                    return res.data
               })
                .then((estadosCiviles) => { return estadosCiviles })
                .catch(error => {
                    if (error.response) {
                        console.log(error.response.data);
                        console.log(error.response.status);
                        console.log(error.response.headers);
                    } else if (error.request) {

                        console.log(error.request);
                    } else {
                        console.log('Error', error.message);
                    }
                    console.log(error.config);
                    console.log(error)
                    throw new Error('A ocurrido un error.', error)
                })
}

export const getTiposPensiones = async (url) => {
    return http.GET(url)
        .then((res) => {
            return res.data;
        })
        .then((tipo_pensiones) => { return tipo_pensiones})
        .catch(error => {
                if (error.response) {
                    console.log(error.response.data);
                    console.log(error.response.status);
                    console.log(error.response.headers);
                } else if (error.request) {

                    console.log(error.request);
                } else {
                    console.log('Error', error.message);
                }
                console.log(error.config);
                console.log(error)
                throw new Error('A ocurrido un error.', error)
        })
    
}

export const guardarPensionado = async (url, data) => {
    return http.POST(url, data)
        .then((res => { }))
        .catch(error => {
            if (error.response) {
                console.log(error.response.data);
                console.log(error.response.status);
                console.log(error.response.headers);
            } else if (error.request) {

                console.log(error.request);
            } else {
                console.log('Error', error.message);
            }
            console.log(error.config);
            console.log(error)
            throw new Error('A ocurrido un error.', error)
        })
}