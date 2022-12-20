import 'https://cdn.jsdelivr.net/npm/axios/dist/axios.min.js';

axios.defaults.headers.post['Content-Type'] = 'application/json';
axios.defaults.headers.post['Accept'] = 'application/json';


axios.interceptors.request.use((config) => {
    return config
}, (error) => {
    return Promise.reject('Error')
})

axios.interceptors.response.use((response) => response,
    (error) => {
        if (error.request.status === 401) {
            window.location.href = '/login'
        }
        return Promise.reject('Error')
})

class HttpServices {

    GET(url, config) {
        return axios.get(url, config)
    }

    POST(url, data, config) {
        return axios.post(url, data, config)
    }

    PUT(url, data, config) {
        return axios.put(url, data, config)
    }

    DELETE(url, config) {
        return axios.delete(url, config)
    }
}

export default new HttpServices()