import React, { useState } from "react";
import {
    Collapse,
    Navbar,
    NavbarToggler,
    NavbarBrand,
    Nav,
    NavItem
} from 'reactstrap'
import HeaderUserArea from "./UserArea";

const NavBarTop = () => {
    const [navbarOpen, toggleNavbar] = useState(false)
    return (
        <Navbar color="light" light expand="md">
            <NavbarBrand href="/">Monte Sua Festa Infantil</NavbarBrand>
            <NavbarToggler onClick={() => toggleNavbar(!navbarOpen)} />
            <Collapse isOpen={navbarOpen} navbar>
                <Nav className="ml-auto" navbar >
                    <NavItem>
                       <HeaderUserArea />
                    </NavItem>
                </Nav>
            </Collapse>
        </Navbar>
    );
}

export default NavBarTop;