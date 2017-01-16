import React, { Component } from 'react';
import axios from 'axios';
import { Grid } from 'react-mdl';

import ConsignmentsTable from '../components/consignments/consignmentsTable';
import ConsignmentStatesHeader from '../components/consignments/consignmentStatesHeader';

import '../sass/table.scss';

class ConsignmentsContainer extends Component {
    constructor(props) {
        super(props);
        this.state = {
            data: { consignments: []},
            type: this.props.route.consignmentState,
            subType: this.props.params.consignmentSubState || null,
            loading: true,
            selectAll: false,
            selectedPage: 1,
            pageSize: 10,
            count: 0,
            stateHeaderLoading: true,
            stateHeaders: []
        }
        this._loadConsignments = this._loadConsignments.bind(this);
        this._selectAll = this._selectAll.bind(this);
        this._loadStateHeaders = this._loadStateHeaders.bind(this);
    }
    componentDidMount() {
        this._loadStateHeaders().then((data) => {
            this.setState({
                stateHeaders: data,
                stateHeadersLoading: false
            });
        });

        this._loadConsignments(this.props.route.consignmentState, this.props.params.consignmentSubState).then((data) => {
            if (data.consignments.length > 0) {
                this.setState({
                    data: data,
                    loading: false,
                    count: data.totalRecords
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
    _loadConsignments(state, substate, take, skip) {

        let baseUrl = `/consignments/${state.toLowerCase()}`;

        if (substate) {
            baseUrl = `/consignments/${state.toLowerCase()}/${substate.toLowerCase()}`;
        }

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
                console.log(response);
                return response.data;
            });
    }
    _loadStateHeaders() {
        const type = this.state.type;
        const url = `/consignments/stateHeaders?type=${type}`;
        
        return axios.get(url)
            .then((response) => {
                console.log('radials', response);
                return response.data;
            });
    }
    _selectPage = (page) => {
        this.setState({
            loading: true
        }, () => {
            this._loadConsignments(this.state.type, this.state.subType, this.state.pageSize, (this.state.pageSize * (page - 1)))
            .then((data) => {
                if (data.consignments.length > 0) {
                    this.setState({
                        data: data,
                        loading: false,
                        count: data.totalRecords
                    });
                } else {
                    this.setState({
                        loading: false,
                        count: 0,
                        data: {consignments:[]}
                    });
                }
            });    
        });
        
    }
    _selectAll() {
        this.setState({ selectAll: !this.state.selectAll });
    }
    render() {
        return(
        <Grid>
            <ConsignmentStatesHeader data={this.state.stateHeaders}/>
            <ConsignmentsTable count={this.state.count} 
                               selectAll={this.state.selectAll}
                               selectAllConsignments={this._selectAll} 
                               selectPage={this._selectPage}
                               loading={this.state.loading} 
                               data={this.state.data}
                               pageSize={this.state.pageSize}
                               consignments={this.state.data.consignments}/>
        </Grid>);
    }
}
        



export default ConsignmentsContainer;