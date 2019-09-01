import React, { useState } from "react";
import {
    Collapse,
    Navbar,
    NavbarToggler,
    NavbarBrand,
    Nav,
    NavItem
} from 'reactstrap'
import EnterArea from "./EnterArea";

const NavBarTop = () => {
    const [navbarOpen, toggleNavbar] = useState(false)
    return (
        <Navbar color="light" light expand="md">
            <NavbarBrand href="/">Monte Sua Festa Infantil</NavbarBrand>
            <NavbarToggler onClick={() => toggleNavbar(!navbarOpen)} />
            <Collapse isOpen={navbarOpen} navbar>
                <Nav className="ml-auto" navbar >
                    <NavItem>
                       <EnterArea />
                    </NavItem>
                </Nav>
            </Collapse>
        </Navbar>
    );
}

export default NavBarTop;