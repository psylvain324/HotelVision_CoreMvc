module.exports = {
    siteMetadata: {
        title: `Travel Vision Blog`,
        author: `Phillip Sylvain`,
        description: `A blog that shows you the power of Travel Vision.`,
        social: {
            twitter: `travel-vision`,
            facebook: 'test',
        },
    },
    plugins: [
        {
            resolve: `gatsby-source-filesystem`,
            options: {
                path: `${__dirname}/content/assets`,
                name: `assets`,
            },
        },
        {
            resolve: `gatsby-plugin-manifest`,
            options: {
                name: `Starter Blog`,
                short_name: `Blog`,
                start_url: `/`,
                background_color: `#f7f0eb`,
                theme_color: `#a2466c`,
                display: `standalone`,
                icon: `content/assets/cheese-icon.png`,
            },
        },
        {
            resolve: `gatsby-plugin-typography`,
            options: {
                pathToConfigModule: `src/utils/typography`,
            },
        },
        `gatsby-plugin-offline`
    ],
}
