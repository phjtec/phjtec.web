import * as React from 'react';
import { Link, NavLink } from 'react-router-dom';

export class NavMenu extends React.Component<{}, {}> {
    public render() {
        return <nav>
            <Link className='logo' to={'/'}><img className='img-responsive' src='./assets/logo.png' width='350' /></Link>
            <ul>
                <li>
                    <NavLink to={'/our-services'}>Our Services</NavLink>
                </li>
            </ul>
            </nav>;
    }
}
