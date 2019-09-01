import React, { useState } from "react";
import { Button } from 'reactstrap'
import ModalEnterArea from "./ModalEnterArea";

const EnterArea = () => {
    const [modalOpen, setmodalOpen] = useState(false)
    return (
        <>
            <Button color="secondary" onClick={() => setmodalOpen(!modalOpen)}>Entrar</Button>
            <ModalEnterArea modalOpen={modalOpen} toggle={() => setmodalOpen(!modalOpen)} />
        </>
    );
}

export default EnterArea;