import React from 'react';
import {
    Button,
    Card,
    Content,
    Grid,
    Cell,
    Tabs,
    Tab } from 'react-mdl';
import Loading from '../components/Loading';
import '../sass/dashboard.scss';
import SimpleChart from '../components/charts/SimpleChart';
import RadialChart from '../components/charts/RadialChart';
import MultiChart from '../components/charts/MultiChart';

class Dashboard extends React.Component {
    render() {
        return (
           this.props.hasLoaded === false ? (
                <Loading />
            )
            :
            (
                <div>
                    <Tabs activeTab={this.props.activeTab} onChange={(tabId) => this.props.setActiveTab(tabId)} ripple>
                        <Tab>Not Shipped</Tab>
                        <Tab>Shipped</Tab>
                    </Tabs>
                    {this.props.activeTab === 0 ? (
                    <Grid>
                        <Cell col={4} tablet={12} phone={12}>
                            <RadialChart Source={this.props.radials} Label="Unallocated" />
                        </Cell>
                        <Cell col={4} tablet={12} phone={12}>
                            <RadialChart Source={this.props.radials} Label="Allocation Failed" />
                        </Cell>
                        <Cell col={4} tablet={12} phone={12}>
                            <RadialChart Source={this.props.radials} Label="Manifest Failed" />
                        </Cell>
                        <Cell col={6} tablet={12} phone={12}>
                            <Card shadow={0} style={{width: '100%' , height: '320px', padding: '20px'}}>
                                <SimpleChart label="State" sourceData={this.props.preDespatchOverviewData} chartType="Line" />
                            </Card>
                        </Cell>
                        <Cell col={6} tablet={12} phone={12}>
                            <Card shadow={0} style={{width: '100%' , height: '320px', padding: '20px'}}>
                                <SimpleChart label="Allocated Carrier" sourceData={this.props.allocatedCarriersData} chartType="HorizontalBar" />
                            </Card>
                        </Cell>
                        <Cell col={12} phone={12}>
                            <Card shadow={0} style={{width: '100%' , height: '320px', padding: '20px'}}>
                                <SimpleChart label="Allocated Carrier Services" sourceData={this.props.allocatedCarrierServicesData} chartType="HorizontalBar" />
                            </Card>
                        </Cell>
                        <Cell col={12} phone={12}>
                            <Card shadow={0} style={{width: '100%' , height: '320px' , padding: '20px' }}>
                                <MultiChart Source={this.props.allocationByCarrierService} LabelPrefix="Week" NullLabelText="Not Allocated" />
                            </Card>
                        </Cell>
                    </Grid>
                    ) : (
                        <div>post despatch</div>
                    )}
            </div>
            ) 
        );
    }    
}

export default Dashboard;