import React, { useState } from "react";
import { Button } from 'reactstrap'
import DialogUserCreateOrEnter from "../Dialog/User/CreateOrEnter/Modal";

const HeaderUserArea = () => {
    const [modalOpen, setmodalOpen] = useState(false)
    return (
        <>
            <Button color="secondary" onClick={() => setmodalOpen(!modalOpen)}>Entrar</Button>
            <DialogUserCreateOrEnter modalOpen={modalOpen} toggle={() => setmodalOpen(!modalOpen)} />
        </>
    );
}

export default HeaderUserArea;