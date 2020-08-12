import React from 'react'

// Componentsnpm start
import Layout from '../components/layout'

class BlogIndex extends React.Component {
    render() {
        return (
            <Layout
                title="Starter Blog"
                subtitle="Built with React and Gatsby">
                <div className="blog-container">
                    <section>
                        <div className="post-summary">
                            <p>January 17th, 2020</p>
                            <h2>Introduction</h2>
                            <p>I started this blog on my 30th Birthday.
                               This isn't a typical Wordpress Blog, I wrote this
                               using React with Gatsby. In this article I will
                               go into various technologies and go into the purpose
                               of this blog and who I am.
                            </p>
                            <button>
                                Read more
                            </button>
                        </div>
                    </section>
                </div>
            </Layout>
        )
    }
}

export default BlogIndex