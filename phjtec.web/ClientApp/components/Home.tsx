import * as React from 'react';
import { RouteComponentProps } from 'react-router';

export class Home extends React.Component<RouteComponentProps<{}>, {}> {
    public render() {
        return <div>
            <h1>Software Development and Consultancy Services</h1>
            <p>Providing software development and consultancy services in and round South Wales. Check out or services page to see what we can do for you.</p>
            </div>;
    }
}
