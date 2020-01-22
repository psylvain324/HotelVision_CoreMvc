import React from 'react'

// Components
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
                               go into the technology and go into the purpose
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


/*<!--Crypto Price Widget-- >
<div id="xchng-ticker" class="xchng-small" data-hue="-72"></div>
    <script type="text/javascript">
        (function() {
        var po = document.createElement("script");
        po.type = "text/javascript";
        po.async = true;
        po.src = "https://hitbtc.com/get_widget?pair=1stbtc";
        var s = document.getElementsByTagName("script")[0];
        s.parentNode.insertBefore(po, s);
    })();
     // You can construct widget dynamically by calling xchng.widget("myDiv", "small", -72, "1stbtc");
</script>*/