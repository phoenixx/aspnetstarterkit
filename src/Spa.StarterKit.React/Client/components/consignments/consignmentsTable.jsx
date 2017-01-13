import React, { Component } from 'react';
import {
    Cell, 
    Card } from 'react-mdl';
import Checkbox from '../checkbox/checkbox';
import Loading from '../Loading';
import Pagination from '../utils/pagination/pagination.jsx';
import ConsignmentsRow from './consignmentsRow';
import '../../sass/table.scss';

class ConsignmentsTable extends Component {
    constructor(props) {
        super(props);
    }
    render() {

        let consignmentArray = [];
        if (this.props.consignments && this.props.consignments.length > 0) {
            consignmentArray = this.props.consignments;
        }

        return(
            <Cell col={12}>
                <h3>{this.props.count} Consignments</h3>
                <Card shadow={0} style={{width: '100%', minHeight: '500px', overflow: 'auto'}} raised>
                    <table className="striped">
                        <thead>
                            <tr>
                                <th>
                                    <Checkbox checked={this.props.selectAll} onChange={() => this.props.selectAllConsignments()} />
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
                            {this.props.loading
                                ? (
                                    <Loading/>
                                )
                                : (
                                    consignmentArray.map((con) => {
                                        return(
                                            <ConsignmentsRow {...con} key={con.consignmentReference} selected={this.props.selectAll}/>
                                        );
                                    })
                                )}
                        </tbody>
                        <tfoot>
                            <tr>
                                <td colSpan="12">
                                    <Pagination totalRecords={this.props.count} pageSize={this.props.pageSize} selectPage={(page) => this.props.selectPage(page)} />
                                </td>
                            </tr>
                        </tfoot>
                    </table>
                </Card>
            </Cell>
        );
    }
}

export default ConsignmentsTable;