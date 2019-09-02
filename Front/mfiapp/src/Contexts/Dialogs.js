import React, { Component, createContext } from 'react'

export const DialogsContext = createContext()

export class DialogsContextProvider extends Component {

    state = {
        dialogEnterOrCreateOpen: false
    }
    toggleDialogEnterOrCreate = () => {
        this.setState((prevState, props) => {
            return { dialogEnterOrCreateOpen: !prevState.dialogEnterOrCreateOpen }
        })
    }

    render() {
        return (
            <DialogsContext.Provider value={{
                ...this.state,
                toggleDialogEnterOrCreate: this.toggleDialogEnterOrCreate,
            }}>
                {this.props.children}
            </DialogsContext.Provider>
        )
    }
}

export default DialogsContextProvider
