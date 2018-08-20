import * as React from 'react'
import { shallow } from 'enzyme'

import App from './index'

var render = function(props) {
  return shallow(<App {...props} />)
}

test('should render "Hello, World!" as title', function() {
  var renderedComponent = render()
  var header = renderedComponent.find('h1')
  expect(header.text()).toBe('Hello, World!')
})
