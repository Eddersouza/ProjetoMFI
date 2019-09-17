import React from 'react'
import { toast } from 'react-toastify';
import MessageToast from '../../UI/Toast/Message';

export const OpenToastError = (messages) => {
    toast.error(<MessageToast messages={messages} type='error' />, {
        position: toast.POSITION.TOP_CENTER
    })
}

export const OpenToastInfo = (messages) => {
    toast.info(<MessageToast messages={messages} type='info' />, {
        position: toast.POSITION.TOP_CENTER
    })
}

export const OpenToastSuccess = (messages) => {
    toast.success(<MessageToast messages={messages} type='success' />, {
        position: toast.POSITION.TOP_CENTER
    })
}

export const OpenToastWarn = (messages) => {
    toast.warn(<MessageToast messages={messages} type='warn' />, {
        position: toast.POSITION.TOP_CENTER
    })
}