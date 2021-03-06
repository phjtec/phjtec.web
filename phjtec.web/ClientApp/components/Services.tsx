﻿import * as React from 'react';
import { RouteComponentProps } from 'react-router';
import 'isomorphic-fetch';

interface ServicesState {
    services: ProvidedService[];
    loading: boolean;
}


export class Services extends React.Component<RouteComponentProps<ProvidedService>, ServicesState> {
    constructor(props: RouteComponentProps<ProvidedService>) {
        super(props);

        this.state = { services: [], loading: true };


            fetch('api/services')
                .then(response => response.json() as Promise<ProvidedService[]>)
                .then(data => {
                    this.setState({ services: data, loading: false });
                });
        
        
    }

    public render() {
        let contents = this.state.loading 
            ? <p><em>Loading...</em></p>
            : Services.renderServices(this.state.services);

        return <div>{contents}</div>;
    }

    private static renderServices(services: ProvidedService[]) {
        return <section id='ourServices'>
            {
                services.map(s =>
                    <div className='service'>
                        <h2>{s.name}</h2>
                        <p>{s.description}</p>
                        {
                            s.serviceRoute !== null
                                ? <a href={'/we-provide/' + s.serviceRoute }>read more &gt;</a>
                                : ''
                        }
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