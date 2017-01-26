import React, { Component } from 'react';
import axios from 'axios';
import { Card, CardTitle, CardText } from 'react-mdl';
import OptionalProperty from '../../utils/optionalProperty';
import Loading from '../../Loading';

class MetadataTable extends Component {
    constructor(props) {
        super(props);
    }
    render() {
        return(
            <table className="metadata-table">
                <thead>
                    <tr>
                        <th>Key</th>
                        <th>Bool</th>
                        <th>DateTime</th>
                        <th>Int</th>
                        <th>String</th>
                    </tr>
                </thead>
                <tbody>
                    {this.props.items.map((item) => {
                        return(
                            <tr>
                                <td>{item.keyValue}</td>
                                <td><OptionalProperty>{item.boolValue}</OptionalProperty></td>
                                <td><OptionalProperty>{item.dateTimeValue}</OptionalProperty></td>
                                <td><OptionalProperty>{item.intValue}</OptionalProperty></td>
                                <td><OptionalProperty>{item.stringValue}</OptionalProperty></td>
                            </tr>
                        );
                    })}
                </tbody>
            </table>
        );
    }
}

class Metadata extends Component {
    constructor(props) {
        super(props);
    }
    render() {
        const consignmentMetadata = this.props.metadata.filter((metadata) => {
            return metadata.type === 1;
        });
        console.log(consignmentMetadata);
        const packageMetadata = this.props.metadata.filter((metadata) => {
            return metadata.type === 2;
        });
        const itemMetadata = this.props.metadata.filter((metadata) => {
            return metadata.type === 3;
        });

        if (this.props.metadata.length === 0) {
            return (
                <div>
                    <span className="info-message">There is no metadata associated with this consignment.</span>
                </div>
                );
            } else {
                return (
                    <div>
                        {consignmentMetadata.length > 0 ? (
                            consignmentMetadata.map((metadata) => {
                                return(
                                    <div className="metadata-container">
                                        <div className="metadata-section">
                                            {`Consignment ${metadata.reference}`}
                                        </div>
                                        <MetadataTable items={metadata.items}/>
                                    </div>
                                );
                            })
                        ) : (null)}
                        {packageMetadata.length > 0 ? (
                            packageMetadata.map((metadata) => {
                                return(
                                    <div className="metadata-container">
                                        <div className="metadata-section">
                                            {`Package ${metadata.reference}`}
                                        </div>
                                        <MetadataTable items={metadata.items}/>
                                    </div>
                                );
                            })
                        ) : (null)}
                        {itemMetadata.length > 0 ? (
                            itemMetadata.map((metadata) => {
                                return(
                                    <div className="metadata-container">
                                        <div className="metadata-section">
                                            {`Item ${metadata.reference}`}
                                        </div>
                                        <MetadataTable items={metadata.items}/>
                                    </div>
                                );
                            })
                        ) : (null)}
                    </div>
                );
            }
    }
}

class MetadataTab extends Component {
    constructor(props) {
        super(props);
        this.state = {
            loading: true,
            metadata: []
        }
    }
    componentDidMount() {
        const baseUrl = `/metadata/${this.props.consignmentReference}`;

        return axios.get(baseUrl).then((result) => {
            this.setState({ metadata: result.data.metadata, loading: false });
        });
    }
    render() {
        return(
             <Card shadow={0} raised style={{minHeight: '300px', width: '100%'}}>
                <CardTitle>Metadata</CardTitle>
                <CardText className="tab--cardtext">
                    {this.state.loading ? (<Loading />) : (<Metadata metadata={this.state.metadata} />)}
                </CardText>
             </Card>
        );
    }
}

export default MetadataTab;
