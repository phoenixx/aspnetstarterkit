import React, { Component } from 'react';
import { Card, CardTitle, CardText } from 'react-mdl';
import { DateTime } from '../../utils/dateFormatting';

class PackageDocumentation extends Component {
    constructor(props) {
        super(props);
    }
    render() {
        return(
            <div className="package-documents">
                <h5>{this.props.reference}</h5>
                <div className="document-contents--row">
                    <div className="document-contents--column">
                        {this.props.reference}
                    </div>
                    <div className="document-contents--column">
                        <a href={`/documents/labels/package/${this.props.consignmentReference}/${this.props.reference}`} target="_blank">
                            Print package label
                        </a>
                    </div>
                    <div className="document-contents--column">
                        {this.props.dateLabelsWereFirstPrinted ? (
                            <span>
                                Labels first printed: <DateTime value={this.props.dateLabelsWereFirstPrinted} />
                            </span>
                        ) : (null)}
                    </div>
                </div>
                <div className="document-contents--row">
                    <div className="document-contents--column">
                        {this.props.reference}
                    </div>
                    <div className="document-contents--column">
                        <a href={`/documents/cn22/${this.props.consignmentReference}/${this.props.reference}`} target="_blank">
                            Print CN22
                        </a>
                    </div>
                </div>
                <div className="document-contents--row">
                    <div className="document-contents--column">
                        {this.props.reference}
                    </div>
                    <div className="document-contents--column">
                        <a href={`/documents/cn23/${this.props.consignmentReference}/${this.props.reference}`} target="_blank">
                            Print CN23
                        </a>
                    </div>
                </div>
            </div>
        );
    }
}

class DocumentsTab extends Component {
    constructor(props) {
        super(props);
    }
    render() {
        return(
            <Card shadow={0} raised style={{minHeight: '300px', width: '100%'}}>
                <CardTitle>Documents</CardTitle>
                <CardText className="tab--cardtext">
                    <div className="document-container">
                        <div className="document-section">
                            Consignment documentation
                        </div>
                        <div className="document-contents">
                            <div className="document-contents--row">
                                <div className="document-contents--column">
                                    {this.props.consignment.reference}
                                </div>
                                <div className="document-contents--column">
                                    <a href={`/documents/labels/consignment/${this.props.consignment.reference}`} target="_blank">
                                        Print all labels
                                    </a>
                                </div>
                                <div className="document-contents--column">
                                    {this.props.consignment.dateLabelsWereFirstPrinted ? (
                                        <span>
                                            Labels first printed: <DateTime value={this.props.consignment.dateLabelsWereFirstPrinted} />
                                        </span>
                                    ) : (null)}
                                </div>
                            </div>
                            <div className="document-contents--row">
                                <div className="document-contents--column">
                                    {this.props.consignment.reference}
                                </div>
                                <div className="document-contents--column">
                                    <a href={`/documents/commercialinvoice/consignment/${this.props.consignment.reference}`} target="_blank">
                                        Print commercial invoice
                                    </a>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div className="document-container">
                        <div className="document-section">
                            Package documentation
                        </div>
                        <div className="document-contents">
                            {this.props.consignment.packages.map((pkg) => {
                                return(
                                    <PackageDocumentation {...pkg} consignmentReference={this.props.consignment.reference} dateLabelsWereFirstPrinted={this.props.consignment.dateLabelsWereFirstPrinted} />
                                );
                            })}
                        </div>
                    </div>
                </CardText>
            </Card>
        );
    }
}

export default DocumentsTab;