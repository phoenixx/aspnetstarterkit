import React, { Component } from 'react';
import axios from 'axios';
import {
    Grid,
    Cell, 
    Card } from 'react-mdl';
import Checkbox from '../components/checkbox/checkbox';
import FontIcon from 'react-toolbox/lib/font_icon';
import { ShortDate, DateTime } from '../components/utils/dateFormatting';
import { FormattedNumber } from 'react-intl'; //todo extract to utility component
import Loading from '../components/Loading';
import Pagination from '../components/utils/pagination/pagination.jsx';
import { Link } from 'react-router';
import '../sass/table.scss';

class ConsignmentsContainer extends Component {
    constructor(props) {
        super(props);
        this.state = {
            data: { consignments: []},
            //consignments: [],
            type: this.props.route.consignmentState,
            loading: true,
            selectAll: false,
            selectedPage: 1,
            pageSize: 10,
            count: 0
        }
        this._loadData = this._loadData.bind(this);
        this._selectAll = this._selectAll.bind(this);
    }
    componentDidMount() {
        this._loadData(this.props.route.consignmentState).then((data) => {
            if (data.consignments.length > 0) {
                this.setState({
                    //consignments: data.consignments.map(cons => (Object.assign({}, cons, {selected: false}))),
                    data: data,
                    loading: false,
                    count: data.consignments.length
                });
            } else {
                this.setState({
                    loading: false,
                    count: 0,
                    data: {consignments:[]}
                });
            }

        });
    }
    _loadData(state, take, skip) {
        let baseUrl = `/consignments/${state.toLowerCase()}`;

        //add take skip....
        let hasQuery = false;
        if (skip) {
            baseUrl = `${baseUrl}?skip=${skip}`;
            hasQuery = true;
        }

        if (take) {
            const delimeter = hasQuery ? '&' : '?';
            baseUrl = `${baseUrl}${delimeter}take=${take}`;
        }

        console.log('getting data from ' + baseUrl);

        return axios.get(baseUrl)
            .then(function(response) {
                return response.data;
            });
    }
    _selectPage = (page) => {
        this._loadData(this.state.type, this.state.pageSize, (this.state.pageSize * (page - 1)));
    }
    _selectAll() {
        this.setState({ selectAll: !this.state.selectAll });
    }
    render() {
        return(
        <Grid>
            <Cell col={12}>
                <h3>{this.state.count} Consignments</h3>
                <Card shadow={0} style={{width: '100%', minHeight: '500px', overflow: 'auto'}} raised>
                    <table className="striped">
                        <thead>
                            <tr>
                                <th>
                                    <Checkbox checked={this.state.selectAll} onChange={() => this._selectAll()}/>
                                </th>
                                <th className="left">Consignment Reference</th>
                                <th className="left">Client Reference</th>
                                <th>Date Created</th>
                                <th>Weight (Kg)</th>
                                <th>Value</th>
                                <th>Shipping Date</th>
                                <th>Required Delivery Date</th>
                                <th>Earliest Delivery Date</th>
                                <th className="left">State</th>
                                <th className="left">Destination</th>
                                <th>Labels Printed?</th>
                            </tr>
                            </thead>
                            <tbody>
                            {this.state.loading ? (
                            <Loading/>
                            ) : (
                            this.state.data.consignments.map((con) => {
                                return(
                                <ConsignmentRow {...con} key={con.consignmentReference} selected={this.state.selectAll}/>
                                );
                                })
                            )}
                            
                        </tbody>
                        <tfoot>
                            <tr>
                                <td colSpan="12">
                                    <Pagination totalRecords={this.state.count} pageSize={this.state.pageSize} selectPage={(page) => this._selectPage(page)}/>
                                </td>
                            </tr>
                        </tfoot>
                    </table>
                </Card>
            </Cell>
        </Grid>);
    }
}

const RowModel = {
    consignmentReference: {type: String},
    created: {type: Date}
}
        
class ConsignmentRow extends Component {
    constructor(props) {
        super(props);
        this.state = {
            selected: this.props.selected //initial
        }

        this._selectRow = this._selectRow.bind(this);
    }
    _selectRow() {
        this.setState({
            selected: !this.state.selected
        });
    }
    render() {
        return(
            <tr className={(this.state.selected || this.props.selected) ? 'selected' : null} >
                <td><Checkbox checked={this.state.selected || this.props.selected} onChange={() => this._selectRow()} /></td>
                <td>
                    <Link to={`/consignment/${this.props.consignmentReference}`} >
                        {this.props.consignmentReference}
                    </Link>
                </td>
                <td>{this.props.clientReference}</td>
                <td className="center"><DateTime value={this.props.created} /></td>
                <td className="center"><FormattedNumber value={this.props.weight} /></td>
                <td className="center"><FormattedNumber value={this.props.value.amount} style="currency" currency={this.props.value.currency.isoCode} /></td>
                <td className="center"><ShortDate value={this.props.shippingDate} /></td>
                <td className="center">
                    {this.props.requestedDeliveryDate !== null
                        ? (<ShortDate value={this.props.requestedDeliveryDate.date} />)
                        : (null)}
                </td>
                <td><ShortDate value={this.props.earliestDeliveryDate} /></td>
                <td>{this.props.consignmentState}</td>
                <td>{this.props.destinationAddress}</td>
                <td className="center">{this.props.haveLabelsEverBeenPrinted ? (<FontIcon value='done' />) : (<FontIcon value='clear'/>)}</td>
            </tr>
        );
    }
}


export default ConsignmentsContainer;