import React, { Component } from 'react';
import { Card, CardMedia, CardTitle, CardText, CardActions } from 'react-toolbox/lib/card';
import {Button} from 'react-toolbox/lib/button';
import { TextDate } from '../utils/dateFormatting';
import DatePicker from 'react-toolbox/lib/date_picker';
import moment from 'moment';
import Theme from '../../sass/chartControls.scss';

class ChartControls extends Component {
    constructor(props) {
        super(props);
        this.state = {
            showControls: false,
            startDate: moment(this.props.startDate).toDate(),
            endDate: moment(this.props.endDate).toDate(),
            today: moment().toDate()
        }
        this._toggleControls = this._toggleControls.bind(this);
        this._handleStartDateChange = this._handleStartDateChange.bind(this);
        this._handleEndDateChange = this._handleEndDateChange.bind(this);
        this._selectDates = this._selectDates.bind(this);
        this._formatDateFilter = this._formatDateFilter.bind(this);
    }

    _toggleControls() {
        this.setState({
            showControls: !this.state.showControls
        });
    }
    _handleStartDateChange(value) {
        this.setState({ startDate: value });
    }
    _handleEndDateChange(value) {
        this.setState({ endDate: value });
    }
    _formatDateFilter(value) {
        return moment(value).toISOString();
    }
    _selectDates() {
        if (this.props.reload) {

            this.props.reload(
                this._formatDateFilter(this.state.startDate),
                this._formatDateFilter(this.state.endDate));

            this._toggleControls();

        }
    }
    render() {
        return(
            <Card theme={Theme}>
                <CardText theme={Theme}>
                        <span className="chart-controls--header">
                            Showing data from <TextDate value={this.props.startDate}/> to <TextDate value={this.props.endDate}/>.
                        </span>
                        <Button style={{float:'right'}} raised primary icon="filter_list" onMouseUp={this._toggleControls}>
                            {this.state.showControls ? 'Hide' : 'Change'}
                        </Button>
                </CardText>
                {this.state.showControls? (
                    <CardText >
                        <div className="chart-controls--controls">
                            <DatePicker label="Start Date" maxDate={this.state.endDate} value={this.state.startDate} onChange={this._handleStartDateChange} autoOk/>
                            <DatePicker label="End Date" minDate={this.state.startDate} maxDate={this.state.today} value={this.state.endDate} onChange={this._handleEndDateChange} autoOk/>
                        </div>
                        <div className="chart-controls--footer">
                            <Button raised primary icon="done" onMouseUp={this._selectDates}>
                                OK
                            </Button>
                        </div>
                    </CardText>
                ): null}
                
            </Card>
        );
    }
}

export default ChartControls;