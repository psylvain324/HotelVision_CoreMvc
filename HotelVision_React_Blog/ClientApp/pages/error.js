import React from 'react'

import Layout from '../components/layout'

class NotFoundPage extends React.Component {
    render() {
        return (
            <Layout location={this.props.location} title="404 Page Not Found">
                <h1>Not Found</h1>
                <p>This Route does not exist.</p>
            </Layout>
        )
    }
}

export default NotFoundPage
