import React, { Component } from 'react';
import { Link } from 'react-router-dom';
import { Glyphicon, Nav, Navbar, NavItem } from 'react-bootstrap';
import { LinkContainer } from 'react-router-bootstrap';
import './NavMenu.css';

export class NavMenu extends Component {
  displayName = NavMenu.name

  render() {
    return (
      <Navbar inverse fixedTop fluid collapseOnSelect>
        <Navbar.Header>
          <Navbar.Brand>
            <Link to={'/'}>LastCallBase</Link>
          </Navbar.Brand>
          <Navbar.Toggle />
        </Navbar.Header>
        <Navbar.Collapse>
          <Nav>
            <LinkContainer to={'/'} exact>
              <NavItem>
                <Glyphicon glyph='home' /> Home
              </NavItem>
            </LinkContainer>
            <LinkContainer to={'/counter'}>
                 <NavItem>
                        <Glyphicon glyph='education' /> Simple Demo
                 </NavItem>
            </LinkContainer>
            <LinkContainer to={'/mealoffers'}>
                 <NavItem>
                    <Glyphicon glyph='th-list' /> Show Meal Offers
                </NavItem>
            </LinkContainer>
            <LinkContainer to={'/registersubscriber'}>
                <NavItem>
                    <Glyphicon glyph='th-list' /> Register Subscriber
                </NavItem>
             </LinkContainer>
             <LinkContainer to={'/registersupplier'}>
                <NavItem>
                    <Glyphicon glyph='th-list' /> Register Supplier
                </NavItem>
             </LinkContainer>
             <LinkContainer to={'/baseservice'}>
                <NavItem>
                    <Glyphicon glyph='th-list' /> Base Service Example
                </NavItem>
             </LinkContainer>
                    <LinkContainer to={'/postservice'}>
                        <NavItem>
                            <Glyphicon glyph='th-list' /> Post Example
                </NavItem>
                    </LinkContainer>
                    <LinkContainer to={'/fetchsubscriberandpreferences'}>
                        <NavItem>
                            <Glyphicon glyph='th-list' /> Complex Object Fetch
                </NavItem>
                    </LinkContainer>
          </Nav>
        </Navbar.Collapse>
      </Navbar>
    );
  }
}
