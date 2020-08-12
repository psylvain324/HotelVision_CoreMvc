import * as React from 'react';
import ReactDOM from 'react-dom';
import { connect } from 'react-redux';
import NavMenu from '..//components/NavMenu';
import Layout from '..//components/Layout';

const LayoutBasic = () => {
  return (
    <div>
      <p>Header</p>
      <p>Foot</p>
    </div>
  )
}

const TemplateBasic = () => {
  return (
    <div>
      <h1>Page Title</h1>
      <p>Page Content</p>
    </div>
  )
}

const BlogLayout = () => {
  return (
    <div>
      {BlogNavMenu}
      {BlogLayout}
    </div>
  )
}

const BlogNavMenu = () => {
  return (
    <div>
      {NavMenu}
    </div>
  )
}

const Home = () => (
  <div>
    <h1>Travel-Vision Blog Home</h1>
  </div>
);

ReactDOM.render(<BlogLayout></BlogLayout>, document.getElementById('app'));

export default connect()(Home);
