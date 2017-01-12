import React, { Component, PropTypes } from 'react';
import {Button, IconButton} from 'react-toolbox/lib/button';

import '../../../sass/pagination.scss';

class Pagination extends Component {
    static propTypes = {
        next: PropTypes.func.required,
        previous: PropTypes.func.required,
        first: PropTypes.func.required,
        last: PropTypes.func.required,
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
    constructor(props) {
        super(props);
        this.state = {
            currentPage: 1,
            pages: 0
        }
    }
    componentDidMount = () => {
        const pages = Math.floor(this.props.totalRecords / this.props.pageSize);
        this.setState({
            currentPage: 1,
            pages: pages
        });
    }
    render() {
        return(
            <div>
                <PagerButtons 
                    maxPages={this.props.maxPages}
                    pages={this.state.pages}
                    currentPage={this.state.currentPage}
                    selectPage={this._selectPage}
                    selectFirstPage={this._firstPage}
                    selectLastPage={this._lastPage}/>
            </div>
        );
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
        let split = false;

        if (this.props.pages > this.props.maxPages) {
            pages = this.props.maxPages;
            split = true;
        }

        const pageArray = [];
        for (let page = 1; page <= pages; page++) {
            pageArray.push(page);
        }

        if (split) {
            const splitPoint = Math.floor(pages / 2);
            let left = [];
            for (let current = this.props.currentPage;);
            left = [1, 2, 3, 4, 5]; //take current page into account

            //take first split point
            //then last split point and add a ... in between
            left = pageArray.slice(0, splitPoint);
            let right = [];
            for (let i = splitPoint - 1; i >= 0; i--) {
                right.push(this.props.pages - i);
            }
            
            const firstDisabled = this.props.currentPage === 1;
            const lastDisabled = this.props.currentPage === this.props.pages;

            return (
                     <ul className="pagination">
                         <li>
                             <Button primary className="pager" icon="chevron_left" disabled={firstDisabled} onClick={() => this.props.selectFirstPage()}></Button>
                         </li>
                         {left.map((p) => {
                            let className = "pager";
                            if (p === this.props.currentPage) {
                                className += " active";
                            }
                            return(
                                <li>
                                    <Button primary className={className} onClick={() => this._selectPage(p)}>{p}</Button>
                                </li>
                            );
                         })}
                        <li>
                            <Button primary className="pager" icon="chevron_right" disabled={lastDisabled} onClick={() => this.props.selectLastPage()}/>
                        </li>
                     </ul>
            );

        } else {
            return(
                <ul className="pagination">
                    {pageArray.map((p) => {
                        return(
                            <li>
                                <Button primary className="pager">{p}</Button>
                            </li>
                        );
                    })}    
                </ul>
                
            );
        }
    }
}

export default Pagination;