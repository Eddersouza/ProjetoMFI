import React from 'react'
import {
    Col,
    Row,
} from 'reactstrap';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'

const iconType = (type) => {
    switch (type) {
        case 'error':
            return <FontAwesomeIcon className="text-danger" icon="times" />
        case 'success':
            return <FontAwesomeIcon className="text-success" icon="check" />
        case 'warn':
            return <FontAwesomeIcon className="text-warning" icon="exclamation" />
        case 'info':
        default:
            return <FontAwesomeIcon className="text-info" icon="question" />
    }
}

const MessageToast = ({ closeToast, messages, type }) => (
    <Row>
        <Col md={2} className="btn btn-light">
            {iconType(type)}
        </Col>
        <Col >
            <div>
                {messages.map((errorMessage, index) => (
                    <div key={index}>{errorMessage}</div>
                ))}
            </div>
        </Col>
    </Row>
)

export default MessageToast
