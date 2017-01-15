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

import ConsignmentsTable from '../components/consignments/consignmentsTable';

import '../sass/table.scss';

class ConsignmentsContainer extends Component {
    constructor(props) {
        super(props);
        this.state = {
            data: { consignments: []},
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
    _loadData(state, take, skip) {
        let baseUrl = `/consignments/${state.toLowerCase()}`;

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
        this.setState({
            loading: true
        }, () => {
            this._loadData(this.state.type, this.state.pageSize, (this.state.pageSize * (page - 1)))
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