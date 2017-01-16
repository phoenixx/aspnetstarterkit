import React, { Component, PropTypes } from 'react';
import {Button, IconButton} from 'react-toolbox/lib/button';

import '../../../sass/pagination.scss';

class Pagination extends Component {
    static propTypes = {
        selectPage: PropTypes.func.required,
        totalRecords: PropTypes.number.required,
        pageSize: PropTypes.number,
        maxPages: PropTypes.number
    }

    static defaultProps = {
        pageSize: 10,
        maxPages: 10
    }
    _selectPage = (selectedPage) => {
        console.log(`parent ${selectedPage}`);
        if (selectedPage <= this.state.pages && selectedPage > 0 && this.state.currentPage !== selectedPage) {
            this.props.selectPage(selectedPage);
            this.setState({
                currentPage: selectedPage
            });    
        }
    }
    _firstPage = () => {
        this._selectPage(1);
    }
    _lastPage = () => {
        this._selectPage(this.state.pages);
    }
    _nextPage = () => {
        if (this.state.currentPage < this.state.pages) {
            this._selectPage(this.state.currentPage + 1);
        }
    }
    _previousPage = () => {
        if (this.state.currentPage > 1) {
            this._selectPage(this.state.currentPage - 1);
        }
    }
    constructor(props) {
        super(props);
        this.state = {
            currentPage: 1,
            pages: 0
        }
    }
    componentWillReceiveProps = (nextProps) => {
        const pages = Math.ceil(nextProps.totalRecords / nextProps.pageSize);
        this.setState({
            pages: pages
        });
    }
    render() {
        if (this.props.totalRecords <= this.props.pageSize) {
            return(
                <div>
                    <ul className="pagination">
                        <li>
                            <Button primary className="pager" icon="skip_previous" disabled></Button>
                        </li>
                        <li>
                            <Button primary className="pager" icon="fast_rewind" disabled></Button>
                        </li>
                        <li>
                            <Button primary className='pager active'>1</Button>
                        </li>
                         <li>
                            <Button primary className="pager" icon="fast_forward" disabled />
                         </li>
                        <li>
                            <Button primary className="pager" icon="skip_next" disabled />
                        </li>
                    </ul>
                </div>
            );
        } else {
            return(
                <div>
                    <PagerButtons 
                        maxPages={this.props.maxPages}
                        pages={this.state.pages}
                        currentPage={this.state.currentPage}
                        selectPage={this._selectPage}
                        selectFirstPage={this._firstPage}
                        selectLastPage={this._lastPage}
                        selectNextPage={this._nextPage}                              
                        selectPreviousPage={this._previousPage} />
                </div>
        );    
        }
        
    }
}

class PagerButtons extends Component {
    constructor(props) {
        super(props);
    }
    _selectPage = (page) => {
        this.props.selectPage(page);
    }

    render() {
        let pages = this.props.pages;

        if (this.props.pages > this.props.maxPages) {
            pages = this.props.maxPages;
        }

        const pageList = [];
        for (let page = 1; page <= this.props.pages; page++) {
            pageList.push(page);
        }
        
        const offset = this.props.currentPage === 1 ? pages : this.props.currentPage + pages - 2;
        const start = this.props.currentPage > 1 ? (this.props.currentPage - 2) : this.props.currentPage - 1;

        const left = pageList.slice(start, offset);

        const firstDisabled = this.props.currentPage === 1;
        const lastDisabled = this.props.currentPage === this.props.pages;

        return (
                <ul className="pagination">
                    <li>
                        <Button primary className="pager" icon="skip_previous" disabled={firstDisabled} onClick={() => this.props.selectFirstPage()}></Button>
                    </li>
                    <li>
                        <Button primary className="pager" icon="fast_rewind" disabled={firstDisabled} onClick={() => this.props.selectPreviousPage()}></Button>
                    </li>
                    {left.map((p) => {
                        let className = 'pager';
                        if (p === this.props.currentPage) {
                            className += ' active';
                        }
                        return(
                        <li>
                            <Button primary className={className} onClick={() => this._selectPage(p)}>{p}</Button>
                        </li>
                        );
                    })}
                    <li>
                        <Button primary className="pager" icon="fast_forward" disabled={lastDisabled} onClick={() => this.props.selectNextPage()}/>
                    </li>
                    <li>
                        <Button primary className="pager" icon="skip_next" disabled={lastDisabled} onClick={() => this.props.selectLastPage()}/>
                    </li>
                </ul>
        );
    }
}

export default Pagination;