import { Version } from '@microsoft/sp-core-library';
import { BaseClientSideWebPart } from '@microsoft/sp-webpart-base';

import styles from './TestApp1WebPart.module.scss';

export interface ITestApp1WebPartProps {
}

export default class TestApp1WebPart extends BaseClientSideWebPart<ITestApp1WebPartProps> {

  public render(): void {
    this.domElement.innerHTML = `<div class="${styles.testapp1}"></div>`;
  }

  protected onInit(): Promise<void> {
    return super.onInit();
  }

  protected get dataVersion(): Version {
    return Version.parse('1.0');
  }

}
