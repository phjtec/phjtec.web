import * as React from 'react';
import { NavMenu } from './NavMenu';

export interface LayoutProps {
    children?: React.ReactNode;
}

export class Layout extends React.Component<LayoutProps, {}> {
    public render() {
        return <div className='container-fluid'>
            <header className='col-md-12'>
                <NavMenu />
            </header>
            <div className='row'>              
                <div className='col-md-12 content'>
                    { this.props.children }
                </div>
            </div>
        </div>;
    }
}
