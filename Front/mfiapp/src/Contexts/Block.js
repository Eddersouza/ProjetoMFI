import React, { Component, createContext } from 'react'
import BlockUi from 'react-block-ui';
import 'react-block-ui/style.css';

export const BlockContext = createContext()

class BlockContextProvider extends Component {
    state = {
        blocked: false
    }

    blockPage = () => {
        this.setState({ blocked: true })
    }

    unBlockPage = () => {
        this.setState({ blocked: false })
    }

    render() {
        return (

            <BlockContext.Provider value={{
                ...this.state,
                blockPage: this.blockPage,
                unBlockPage: this.unBlockPage
            }}>
                <BlockUi tag="div" blocking={this.state.blocked}>
                    {this.props.children}
                </BlockUi>
            </BlockContext.Provider>
        )
    }
}

export default BlockContextProvider