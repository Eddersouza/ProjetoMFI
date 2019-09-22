import axios from "axios";
import { OpenToastError, OpenToastWarn } from '../Functions/Toast/Message'
import  configMFI  from  '../config'
//import { getToken } from "./auth";

const Api = axios.create({
    baseURL: configMFI.apiGateway.URL_BASE
});

Api.interceptors.request.use(async config => {
    // const token = getToken();
    // if (token) {
    //     config.headers.Authorization = `Bearer ${token}`;
    // }
    return config;
});

Api.interceptors.response.use(function (response) {
    // Any status code that lie within the range of 2xx cause this function to trigger
    // Do something with response data
    return response;
}, function (error) {

    let obj = {
        teste: "ok",
        err: error
    }
    console.log(obj)
    if (error.response) {
        let errors = error.response.data
        OpenToastWarn(errors.Warnings)
    }
    else {
        let errors = []
        errors.push("Ocorreu um erro ao executar a ação, tente novamente ou entre em contato com o administrador")
        OpenToastError(errors)
    }
    return Promise.reject(error)
})

export default Api