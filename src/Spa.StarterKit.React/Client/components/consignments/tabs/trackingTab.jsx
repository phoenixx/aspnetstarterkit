import React, { Component } from 'react';
import axios from 'axios';
import { Card, CardTitle, CardText } from 'react-mdl';
import { DateTime } from '../../utils/dateFormatting';
import Loading from '../../Loading';
import Table from 'react-toolbox/lib/table';
import FontIcon from 'react-toolbox/lib/font_icon';

class TrackingTab extends Component {
    constructor(props) {
        super(props);
        this.state= {
            loading: true,
            events: []
        }
    }
    componentDidMount() {
        const baseUrl = `/tracking/${this.props.consignmentReference}`;
        return axios.get(baseUrl).then((response) => {
            console.log(response);
            this.setState({ events: response.data.events, loading: false });
        });
    }
    render() {
        return(
             <Card shadow={0} raised style={{minHeight: '300px', width: '100%'}}>
                <CardTitle>Tracking Events</CardTitle>
                <CardText className="tab--cardtext">
                    {this.state.loading ? (<Loading />) : (<TrackingEventTable events={this.state.events} />)}
                </CardText>
             </Card>
        );
    }
}

class TrackingEventTable extends Component {
    constructor(props) {
        super(props);
    }
    render() {
        if (this.props.events.length === 0) {
            return(
                <div className="info-message">
                    <FontIcon value='warning' className="info-message--icon"/>
                    <div className="info-message--text">
                        No tracking events available
                    </div>
                </div>
            );
        }
        return(
            <div>
                <table className="tracking-table">
                    <thead>
                        <tr>
                            <th>Date time</th>
                            <th>Event</th>
                            <th>Location</th>
                        </tr>
                    </thead>
                    <tbody>
                        {this.props.events.map((event) => {
                            return(
                                <tr>
                                    <td>...</td>
                                    <td>...</td>
                                    <td>...</td>
                                </tr>
                            );
                        })}
                    </tbody>
                </table>
            </div>
        );
    }
}

export default TrackingTab;
