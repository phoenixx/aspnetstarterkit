import React, {Component} from 'react';
import axios from 'axios';
import Loading from '../../Loading';
import { Card, CardTitle, CardText } from 'react-mdl';
import { DateTimeSeconds } from '../../utils/dateFormatting';

class History extends Component {
    constructor(props) {
        super(props);
    }
    render() {
        return(
            <table className="history-table">
                <thead>
                    <tr>
                        <th>Event date / time</th>
                        <th>Details</th>
                        <th>User</th>
                    </tr>
                </thead>
                <tbody>
                    {this.props.events.map((event) => {
                        return(
                            <tr>
                                <td>
                                    <DateTimeSeconds value={event.timestamp}/>
                                </td>
                                <td>
                                    {event.message}
                                </td>
                                <td>
                                    {event.username}
                                </td>
                            </tr>
                        );
                    })}
                </tbody>
            </table>
        );
    }
}

class HistoryTab extends Component {
    constructor(props) {
        super(props);
        this.state = {
            loading: true,
            events: []
        }
    }
    componentDidMount() {
        const baseUrl = `/history/${this.props.consignmentReference}`;

        return axios.get(baseUrl).then((response) => {
            this.setState({ events: response.data, loading: false });
        });
    }
    render() {
        return(
            <Card shadow={0} raised style={{ minHeight: '300px', width: '100%' }}>
                <CardTitle>Consignment History</CardTitle>
                <CardText className="tab--cardtext">
                    {this.state.loading ? (<Loading/>) : (<History events={this.state.events}/>)}
                </CardText>
            </Card>
        );    
    }
}

export default HistoryTab;