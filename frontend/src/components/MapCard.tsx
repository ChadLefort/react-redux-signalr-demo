import * as React from 'react';
import { createStyles, withStyles, WithStyles } from '@material-ui/core/styles';
import { IKillFeed } from '../interfaces/killFeed';

type Props = WithStyles<typeof styles> & OwnProps;

type OwnProps = {
  killFeed: IKillFeed;
};

const styles = () =>
  createStyles({
    map: {
      borderRadius: '4px',
      height: '100%',
      width: '100%'
    }
  });

class MapCard extends React.Component<Props> {
  public canvasRef: React.RefObject<HTMLCanvasElement>;
  public canvasContext: CanvasRenderingContext2D | null;
  public mapImage: HTMLImageElement;

  constructor(props: Props) {
    super(props);
    this.canvasRef = React.createRef();
    this.mapImage = new Image();
    this.mapImage.src = `${process.env.PUBLIC_URL}/assets/images/maps/coastline.png`;
  }

  public componentDidMount() {
    this.clearAndDraw();

    if (this.canvasRef.current) {
      this.canvasContext = this.canvasRef.current.getContext('2d');
    }

    this.mapImage.onload = () => {
      if (this.canvasContext && this.canvasRef.current) {
        this.canvasContext.drawImage(this.mapImage, 0, 0, 660, 596);
      }
    };
  }

  public componentWillReceiveProps(nextProps: Props) {
    const max = 600;
    const min = 200;
    const { killFeedItems: currentKillFeedItems } = this.props.killFeed;
    const { killFeedItems: nextKillFeedItems } = nextProps.killFeed;

    if (currentKillFeedItems !== nextKillFeedItems) {
      this.clearAndDraw();
      this.placeMarker(
        Math.floor(Math.random() * (max - min + 1)) + min,
        Math.floor(Math.random() * (max - min + 1)) + min,
        nextKillFeedItems[0].kill.operator.toLowerCase()
      );
      this.placeMarker(
        Math.floor(Math.random() * (max - min + 1)) + min,
        Math.floor(Math.random() * (max - min + 1)) + min,
        nextKillFeedItems[0].death.operator.toLowerCase()
      );
    }
  }

  public clearAndDraw() {
    if (this.canvasRef.current && this.canvasContext) {
      this.canvasContext.clearRect(0, 0, this.canvasRef.current.width, this.canvasRef.current.height);
      this.canvasContext.drawImage(this.mapImage, 0, 0, 660, 596);
    }
  }

  public placeMarker = (x: number, y: number, operator: string) => {
    if (this.canvasRef.current) {
      const icon = new Image();

      icon.src = `${process.env.PUBLIC_URL}/assets/operators/${operator}.svg`;
      icon.onload = () => {
        if (this.canvasRef.current && this.canvasContext) {
          this.canvasContext.drawImage(icon, x - 30 / 2, y - 30, 30, 30);
        }
      };
    }
  };

  public render() {
    const { classes } = this.props;
    return <canvas ref={this.canvasRef} width="660" height="596" className={classes.map} />;
  }
}

export default withStyles(styles)(MapCard);
