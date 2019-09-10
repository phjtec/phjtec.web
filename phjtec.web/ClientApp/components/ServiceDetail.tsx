import * as React from 'react';
import { RouteComponentProps } from 'react-router';
import 'isomorphic-fetch';

interface ServicesState {
    services: ProvidedService[];
    loading: boolean;
}


export class ServiceDetail extends React.Component<RouteComponentProps<ProvidedService>, ServicesState> {
    constructor(props: RouteComponentProps<ProvidedService>) {
        super(props);
        this.state = { services: [], loading: true };

        var serviceRoute = this.props.match.params.serviceRoute;

        fetch('api/services/' + serviceRoute)
            .then(response => response.json() as Promise<ProvidedService[]>)
            .then(data => {
                this.setState({ services: data, loading: false });
            });
    }

    public render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : ServiceDetail.renderServices(this.state.services);

        return <div>{contents}</div>;
    }

    private static renderServices(services: ProvidedService[]) {
        return <section id='ourServices'>
            {
                services.map(s =>
                    <div className='service'>
                        <h2>{s.name}</h2>
                        <div>{s.fullContent || s.description }</div>
                    </div>)
            }
        </section>;
    }
}

interface ProvidedService {
    name: string;
    description: string;
    fullContent: string;
    serviceRoute: string;
}