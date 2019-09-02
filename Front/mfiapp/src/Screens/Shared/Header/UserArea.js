import React, { useContext } from "react";
import { Button } from 'reactstrap'
import DialogUserCreateOrEnter from "../Dialog/User/CreateOrEnter/Modal";
import { DialogsContext } from "../../../Contexts/Dialogs";

const HeaderUserArea = () => {
    const { toggleDialogEnterOrCreate } = useContext(DialogsContext)
    return (
        <>
            <Button color="secondary" onClick={ toggleDialogEnterOrCreate}>Entrar</Button>
            <DialogUserCreateOrEnter  />
        </>
    );
}

export default HeaderUserArea;