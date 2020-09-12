import { MellowWoodProjectTemplatePage } from './app.po';

describe('MellowWoodProject App', function() {
  let page: MellowWoodProjectTemplatePage;

  beforeEach(() => {
    page = new MellowWoodProjectTemplatePage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
